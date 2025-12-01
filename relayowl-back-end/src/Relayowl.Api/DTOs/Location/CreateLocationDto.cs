using System.ComponentModel.DataAnnotations;

namespace Relayowl.Api.DTOs.Location;

public class CreateLocationDto
{
    [Required]
    [MaxLength(20, ErrorMessage = "Location name cannot exceed 20 characters.")]
    public string Name { get; set; } = null!;
}