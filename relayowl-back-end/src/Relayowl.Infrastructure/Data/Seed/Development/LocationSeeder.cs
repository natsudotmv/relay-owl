namespace Relayowl.Infrastructure.Data.Seed.Development;

public static class LocationSeeder
{
    public static void Seed(AppDbContext context)
    {
        if (!context.Locations.Any())
        {
            context.Locations.AddRange(
                new Core.Entities.Location { Name = "Main Bar" },
                new Core.Entities.Location { Name = "Room 101" },
                new Core.Entities.Location { Name = "Room 102" },
                new Core.Entities.Location { Name = "Room 103" },
                new Core.Entities.Location { Name = "Room 104" }
            );
        }
    }
}