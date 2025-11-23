using Relayowl.Core.Entities;
using Relayowl.Core.Respositories;

namespace Relayowl.Core.Services;

public class TicketService(ITicketRepository repository) : ITicketService
{
    public async Task<Ticket?> GetTicketByIdAsync(int id)
    {
        return await repository.GetByIdAsync(id);
    }

    public async Task<List<Ticket>> GetAllTicketsAsync()
    {
        return await repository.GetAllAsync();
    }

    public async Task<Ticket> CreateTicketAsync(Ticket ticket)
    {
        ArgumentNullException.ThrowIfNull(ticket);

        await repository.AddAsync(ticket);
        return ticket;
    }

    public async Task<bool> UpdateTicketAsync(int id, Ticket ticket)
    {
        ArgumentNullException.ThrowIfNull(ticket);

        var existingLocation = await repository.GetByIdAsync(ticket.Id);
        if (existingLocation == null)
            return false;
        
        await repository.UpdateAsync(ticket);
        return true;
    }

    public async Task<bool> DeleteTicketAsync(int id)
    {
        var existingLocation = await repository.GetByIdAsync(id);
        if (existingLocation == null)
            return false;

        await repository.DeleteAsync(existingLocation);
        return true;
    }
}