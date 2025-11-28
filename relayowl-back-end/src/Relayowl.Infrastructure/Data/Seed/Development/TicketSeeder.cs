using Microsoft.EntityFrameworkCore;
using Relayowl.Core.Entities;

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
                    Priority = Priority.High,
                    Status = TicketStatus.New,
                    DepartmentId = 3,
                    LocationId = 2,
                    CreatedById = 1
                },
                new Core.Entities.Ticket
                {
                    Id = 2,
                    Title = "Projector issue",
                    Description = "The projector in Room 102 is flickering.",
                    Priority = Priority.Low,
                    Status = TicketStatus.New,
                    DepartmentId = 3,
                    LocationId = 3,
                    CreatedById = 1
                },
                new Core.Entities.Ticket
                {
                    Id = 3,
                    Title = "Air conditioning problem",
                    Description = "The air conditioning in Room 103 is too cold.",
                    Priority = Priority.Medium,
                    Status = TicketStatus.InProgress,
                    DepartmentId = 3,
                    LocationId = 4,
                    CreatedById = 1
                }
            );
        }
        
        context.SaveChanges();
        
        context.Database.ExecuteSql(
                $"SELECT setval('\"Ticket_Id_seq\"', {context.Tickets.Max(t => t.Id)});"
            );
    }
}