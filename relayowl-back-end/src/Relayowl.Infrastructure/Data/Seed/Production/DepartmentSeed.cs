using Relayowl.Core.Entities;

namespace Relayowl.Infrastructure.Data.Seed.Production;

public static class DepartmentSeed
{
    public static void Seed(AppDbContext context)
    {
        if (!context.Departments.Any())
        {
            context.Departments.AddRange(
                new Department { Name = "Human Resources" },
                new Department { Name = "Finance" },
                new Department { Name = "IT" },
                new Department { Name = "Sales & Marketing" },
                new Department { Name = "Front Office" },
                new Department { Name = "Food & Beverage" },
                new Department { Name = "Finance" }
            );
        }
    }
}