#nullable disable
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Serilog;

namespace Artpress.API.HealthChecks
{
    public static class HealthCheckResponseWriter
    {
        public static Task WriteResponse(HttpContext context, HealthReport report)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            // Log de falhas (CA-05)
            if (report.Status == HealthStatus.Unhealthy || report.Status == HealthStatus.Degraded)
            {
                Log.Warning("Health check status: {Status}", report.Status);
                foreach (var entry in report.Entries)
                {
                    if (entry.Value.Status != HealthStatus.Healthy)
                    {
                        Log.Warning("Health check for '{Check}' failed with status '{Status}' and description: '{Description}'",
                            entry.Key, entry.Value.Status, entry.Value.Description);
                    }
                }
            }

            // Customização da resposta JSON (CA-06)
            var response = new
            {
                Status = report.Status.ToString(),
                TotalDuration = report.TotalDuration.ToString(),
                Checks = report.Entries.Select(e => new
                {
                    Check = e.Key,
                    Status = e.Value.Status.ToString(),
                    Description = e.Value.Description,
                    Duration = e.Value.Duration.ToString(),
                    Data = e.Value.Data.Any() ? e.Value.Data : null
                })
            };

            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(JsonSerializer.Serialize(response, options));
        }
    }
}
