using Microsoft.EntityFrameworkCore;
using Artpress.Domain.Entities;
using System.Reflection;

namespace Artpress.Infrastructure.Data.Context
{
    public class ArtpressDbContext : DbContext
    {
        public ArtpressDbContext(DbContextOptions<ArtpressDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserClaim> UserClaims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
