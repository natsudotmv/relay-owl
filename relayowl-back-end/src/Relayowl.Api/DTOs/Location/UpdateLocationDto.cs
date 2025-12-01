using System.ComponentModel.DataAnnotations;

namespace Relayowl.Api.DTOs.Location;

public class UpdateLocationDto
{
    [Required]
    [MaxLength(20, ErrorMessage = "Location name cannot exceed 20 characters.")]
    public string Name { get; set; } = null!;

}