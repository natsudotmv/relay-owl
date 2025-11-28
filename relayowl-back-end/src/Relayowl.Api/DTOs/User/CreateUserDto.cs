namespace Relayowl.Api.DTOs.User;

public class CreateUserDto
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string Role { get; set; } = null!;  // "Staff", "DepartmentStaff"

    public int? DepartmentId { get; set; }
}