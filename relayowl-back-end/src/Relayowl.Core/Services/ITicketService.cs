using Relayowl.Core.Entities;

namespace Relayowl.Core.Services;

public interface ITicketService
{
    Task<Ticket?> GetTicketByIdAsync(int id);
    Task<List<Ticket>> GetAllTicketsAsync();
    Task<Ticket> CreateTicketAsync(Ticket ticket);
    Task<bool> UpdateTicketAsync(int id, Ticket ticket);
    Task<bool> DeleteTicketAsync(int id);
}