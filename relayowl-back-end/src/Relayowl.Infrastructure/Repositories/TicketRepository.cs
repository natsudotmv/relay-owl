using Microsoft.EntityFrameworkCore;
using Relayowl.Core.Entities;
using Relayowl.Core.Respositories;
using Relayowl.Infrastructure.Data;

namespace Relayowl.Infrastructure.Repositories;

public class TicketRepository(AppDbContext context) : ITicketRepository
{
    public async Task<Ticket?> GetByIdAsync(int id)
    {
        return await context.Tickets.FindAsync(id);
    }

    public async Task<List<Ticket>> GetAllAsync()
    {
        return await context.Tickets.ToListAsync();
    }

    public async Task AddAsync(Ticket ticket)
    {
        ArgumentNullException.ThrowIfNull(ticket);

        await context.Tickets.AddAsync(ticket);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Ticket ticket)
    {
        ArgumentNullException.ThrowIfNull(ticket);
        
        context.Tickets.Update(ticket);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Ticket ticket)
    {
        ArgumentNullException.ThrowIfNull(ticket);
        
        context.Tickets.Remove(ticket);
        await context.SaveChangesAsync();
    }
}