using Microsoft.EntityFrameworkCore;
using Relayowl.Core.Entities;

namespace Relayowl.Infrastructure.Data.Seed.Production;

public static class UserSeeder
{
    public static void Seed(AppDbContext context)
    {
        // Seed initial users if none exist
        if (!context.DomainUsers.Any())
        {
            context.DomainUsers.AddRange(
                new DomainUser
                {
                    Id = 1,
                    FullName = "Super User",
                    Email = "admin@relayowl.com",
                    // TODO: pasword hashing
                    PasswordHash = "superpasswordhash",
                    Role = "Admin",
                    DepartmentId = 1
                }
            );
        }
        context.SaveChanges();
        
        context.Database.ExecuteSql(
                $"SELECT setval('\"DomainUser_Id_seq\"', {context.DomainUsers.Max(u => u.Id)});"
            );
    }
}