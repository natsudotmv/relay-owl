using Relayowl.Api.DTOs.Comment;
using Relayowl.Core.Entities;

namespace Relayowl.Api.DTOs.Ticket;

public class ReadTicketDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }

    public Priority Priority { get; set; }
    public TicketStatus Status { get; set; }

    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; } = null!;

    public int LocationId { get; set; }
    public string LocationName { get; set; } = null!;

    public int CreatedById { get; set; }
    public string CreatedByName { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public List<ReadCommentDto> Comments { get; set; } = new();
}