#nullable disable
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Artpress.Domain.Entities;
using Artpress.Infrastructure.Data.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Artpress.Infrastructure.Data.Seed
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(ArtpressDbContext context, IPasswordHasher<User> passwordHasher)
        {
            // Garante que o banco de dados seja criado.
            await context.Database.MigrateAsync();

            // Verifica se já existem usuários.
            if (!context.Users.Any())
            {
                // Cria o usuário administrador.
                var adminUser = new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Administrador",
                    Email = "admin@artpress.com",
                    CreatedAt = DateTime.UtcNow
                };

                // Gera o hash da senha.
                adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "1234!@#$qwerQWER");

                // Adiciona o usuário ao contexto e salva.
                await context.Users.AddAsync(adminUser);
                await context.SaveChangesAsync();
            }
        }
    }
}
