namespace Relayowl.Api.DTOs.Comment;

public class ReadCommentDto
{
    public int Id { get; set; }
    public string Message { get; set; } = null!;
    
    public int TicketId { get; set; }
    public int UserId { get; set; }

    public DateTime CreatedAt { get; set; }
}