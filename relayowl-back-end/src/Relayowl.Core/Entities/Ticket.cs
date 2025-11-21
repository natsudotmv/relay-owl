namespace Relayowl.Core.Entities;

public class Ticket
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }

    public Priority Priority { get; set; }
    public TicketStatus Status { get; set; }

    public int DepartmentId { get; set; }
    public Department Department { get; set; } = null!;

    public int LocationId { get; set; }
    public Location Location { get; set; } = null!;

    public int CreatedById { get; set; }
    public User CreatedBy { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public List<Comment> Comments { get; set; } = new();
}

public enum Priority { Low, Medium, High }
public enum TicketStatus { New, InProgress, Completed }