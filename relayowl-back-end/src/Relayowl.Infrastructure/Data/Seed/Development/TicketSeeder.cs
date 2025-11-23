namespace Relayowl.Infrastructure.Data.Seed.Development;

public static class TicketSeeder
{
    public static void Seed(AppDbContext context)
    {
        if (!context.Tickets.Any())
        {
            context.Tickets.AddRange(
                new Core.Entities.Ticket
                {
                    Id = 1,
                    Title = "WiFi not working",
                    Description = "The WiFi in Room 101 is not connecting.",
                    DepartmentId = 3,
                    LocationId = 2,
                    CreatedById = 1
                },
                new Core.Entities.Ticket
                {
                    Id = 2,
                    Title = "Projector issue",
                    Description = "The projector in Room 102 is flickering.",
                    DepartmentId = 3,
                    LocationId = 3,
                    CreatedById = 1
                },
                new Core.Entities.Ticket
                {
                    Id = 3,
                    Title = "Air conditioning problem",
                    Description = "The air conditioning in Room 103 is too cold.",
                    DepartmentId = 3,
                    LocationId = 4,
                    CreatedById = 1
                }
            );
        }
    }
}