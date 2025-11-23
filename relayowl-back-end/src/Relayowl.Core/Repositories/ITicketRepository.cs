using Relayowl.Core.Entities;

namespace Relayowl.Core.Respositories;

public interface ITicketRepository
{
    Task<Ticket?> GetByIdAsync(int id);
    Task<List<Ticket>> GetAllAsync();
    Task AddAsync(Ticket ticket);
    Task UpdateAsync(Ticket ticket);
    Task DeleteAsync(Ticket ticket);
}