using Relayowl.Core.Entities;

namespace Relayowl.Core.Services;

public interface ILocationService
{
    Task<Location?> GetLocationByIdAsync(int id);
    Task<List<Location>> GetAllLocationsAsync();
    Task<Location> CreateLocationAsync(Location location);
    Task<bool> UpdateLocationAsync(int id, Location location);
    Task<bool> DeleteLocationAsync(int id);
}