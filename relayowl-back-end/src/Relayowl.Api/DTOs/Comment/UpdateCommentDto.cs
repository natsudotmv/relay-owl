using System.ComponentModel.DataAnnotations;

namespace Relayowl.Api.DTOs.Comment;

public class UpdateCommentDto
{
    [Required]
    [Length(10, 1000, ErrorMessage = "Comment message must be between 10 and 1000 characters.")]
    public string Message { get; set; } = null!;
    
}