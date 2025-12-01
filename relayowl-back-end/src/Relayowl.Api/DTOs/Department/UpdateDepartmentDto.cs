using System.ComponentModel.DataAnnotations;

namespace Relayowl.Api.DTOs.Department;

public class UpdateDepartmentDto
{
    [Required]
    [MaxLength(20, ErrorMessage = "Department name cannot exceed 20 characters.")]
    public string Name { get; set; } = null!;

}