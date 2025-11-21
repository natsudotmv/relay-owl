using Relayowl.Core.Entities;

namespace Relayowl.Core.Respositories;

public interface ILocationRepository
{
    Task<Location?> GetByIdAsync(int id);
    Task<List<Location>> GetAllAsync();
    Task AddAsync(Location location);
    Task UpdateAsync(Location location);
    Task DeleteAsync(Location location);
}