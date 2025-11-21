namespace Relayowl.Core.Entities;

public class Location
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public List<Ticket> Tickets { get; set; } = new();
}