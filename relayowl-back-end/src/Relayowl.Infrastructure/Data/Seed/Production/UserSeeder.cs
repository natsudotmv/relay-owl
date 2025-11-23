using Relayowl.Core.Entities;

namespace Relayowl.Infrastructure.Data.Seed.Production;

public static class UserSeeder
{
    public static void Seed(AppDbContext context)
    {
        // Seed initial users if none exist
        if (!context.Users.Any())
        {
            context.Users.AddRange(
                new User
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
    }
}