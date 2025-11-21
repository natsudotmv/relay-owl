namespace Relayowl.Core.Entities;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public List<Ticket> Tickets { get; set; } = new();
    public List<User> Users { get; set; } = new();
}