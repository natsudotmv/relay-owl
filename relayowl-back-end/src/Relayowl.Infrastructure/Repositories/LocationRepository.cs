using Microsoft.EntityFrameworkCore;
using Relayowl.Core.Entities;
using Relayowl.Core.Respositories;
using Relayowl.Infrastructure.Data;

namespace Relayowl.Infrastructure.Repositories;

public class LocationRepository(AppDbContext context) : ILocationRepository
{
    public async Task<Location?> GetByIdAsync(int id)
    {
        return await context.Locations.FindAsync(id);
    }

    public async Task<List<Location>> GetAllAsync()
    {
        return await context.Locations.ToListAsync();
    }

    public async Task AddAsync(Location location)
    {
        ArgumentNullException.ThrowIfNull(location);

        await context.Locations.AddAsync(location);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Location location)
    {
        ArgumentNullException.ThrowIfNull(location);
        
        context.Locations.Update(location);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Location location)
    {
        ArgumentNullException.ThrowIfNull(location);
        
        context.Locations.Remove(location);
        await context.SaveChangesAsync();
    }
}