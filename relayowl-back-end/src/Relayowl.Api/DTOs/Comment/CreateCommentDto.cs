using System.ComponentModel.DataAnnotations;

namespace Relayowl.Api.DTOs.Comment;

public class CreateCommentDto
{
    [Required]
    [Length(10, 1000, ErrorMessage = "Comment message must be between 10 and 1000 characters.")]
    public string Message { get; set; } = null!;
    
    [Required]
    [Range(1, int.MaxValue)]
    public int TicketId { get; set; }
    
    [Required]
    [Range(1, int.MaxValue)]
    public int UserId { get; set; }
}