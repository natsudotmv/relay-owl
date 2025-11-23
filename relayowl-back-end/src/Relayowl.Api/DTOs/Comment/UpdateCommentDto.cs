namespace Relayowl.Api.DTOs.Comment;

public class UpdateCommentDto
{
    public string Message { get; set; } = null!;
    
    public int TicketId { get; set; }
    public int UserId { get; set; }
}