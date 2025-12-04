using System.ComponentModel.DataAnnotations;

namespace Relayowl.Api.DTOs.Account;

public class CreateAccountDto
{
    [Microsoft.Build.Framework.Required]
    [MaxLength(100, ErrorMessage = "Full name cannot exceed 100 characters.")]
    public string FullName { get; set; } = null!;
    
    [Required]
    [EmailAddress(ErrorMessage = "Invalid email address format.")]
    public string Email { get; set; } = null!;
    
    [Required]
    public string? Password { get; set; }
}