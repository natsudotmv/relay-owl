using Microsoft.EntityFrameworkCore;
using Relayowl.Core.Entities;

namespace Relayowl.Infrastructure.Data.Seed.Production;

public static class DepartmentSeed
{
    public static void Seed(AppDbContext context)
    {
        if (!context.Departments.Any())
        {
            context.Departments.AddRange(
                new Department { Id=1, Name = "Human Resources" },
                new Department { Id=2, Name = "Finance" },
                new Department { Id=3, Name = "IT" },
                new Department { Id=4, Name = "Sales & Marketing" },
                new Department { Id=5, Name = "Front Office" },
                new Department { Id=6, Name = "Food & Beverage" },
                new Department { Id=7, Name = "Finance" }
            );
        }
        context.SaveChanges();
        
        context.Database.ExecuteSql(
                $"SELECT setval('\"Department_Id_seq\"', {context.Departments.Max(d => d.Id)});"
            );
    }
}