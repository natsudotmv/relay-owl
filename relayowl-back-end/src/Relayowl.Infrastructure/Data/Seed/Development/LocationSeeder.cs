using Microsoft.EntityFrameworkCore;

namespace Relayowl.Infrastructure.Data.Seed.Development;

public static class LocationSeeder
{
    public static void Seed(AppDbContext context)
    {
        if (!context.Locations.Any())
        {
            context.Locations.AddRange(
                new Core.Entities.Location { Id = 1, Name = "Main Bar" },
                new Core.Entities.Location { Id = 2, Name = "Room 101" },
                new Core.Entities.Location { Id = 3, Name = "Room 102" },
                new Core.Entities.Location { Id = 4, Name = "Room 103" },
                new Core.Entities.Location { Id = 5, Name = "Room 104" }
            );
        }

        context.SaveChanges();

        context.Database.ExecuteSql(
            $"SELECT setval('\"Location_Id_seq\"', {context.Locations.Max(l => l.Id)});"
        );
    }
}