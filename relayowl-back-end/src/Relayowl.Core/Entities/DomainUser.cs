namespace Relayowl.Core.Entities;

public class DomainUser
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string Role { get; set; } = null!;  // "Staff", "DepartmentStaff", "Admin"

    public int? DepartmentId { get; set; }
    public Department? Department { get; set; }

    public List<Ticket> CreatedTickets { get; set; } = new();
    public List<Comment> Comments { get; set; } = new();
}