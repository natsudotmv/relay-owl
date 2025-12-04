namespace Relayowl.Core.Entities;

public class Comment
{
    public int Id { get; set; }
    public string Message { get; set; } = null!;
    
    public int TicketId { get; set; }
    public Ticket? Ticket { get; set; }
    
    public int DomainUserId { get; set; }
    public DomainUser DomainUser { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}
