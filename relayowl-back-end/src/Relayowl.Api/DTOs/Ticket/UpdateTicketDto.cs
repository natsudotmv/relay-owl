using Relayowl.Core.Entities;

namespace Relayowl.Api.DTOs.Ticket;

public class UpdateTicketDto
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }

    public Priority Priority { get; set; }
    public TicketStatus Status { get; set; }

    public int DepartmentId { get; set; }
    public int LocationId { get; set; }
}