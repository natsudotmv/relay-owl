using Relayowl.Core.Entities;
using Relayowl.Core.Respositories;

namespace Relayowl.Core.Services;

public class LocationService(ILocationRepository repository) : ILocationService
{
    public async Task<Location?> GetLocationByIdAsync(int id)
    {
        return await repository.GetByIdAsync(id);
    }

    public async Task<List<Location>> GetAllLocationsAsync()
    {
        return await repository.GetAllAsync();
    }

    public async Task<Location> CreateLocationAsync(Location location)
    {
        ArgumentNullException.ThrowIfNull(location);

        await repository.AddAsync(location);
        return location;
    }

    public async Task<bool> UpdateLocationAsync(int id, Location location)
    {
        ArgumentNullException.ThrowIfNull(location);

        var existingLocation = await repository.GetByIdAsync(location.Id);
        if (existingLocation == null)
            return false;
        
        await repository.UpdateAsync(location);
        return true;
    }

    public async Task<bool> DeleteLocationAsync(int id)
    {
        var existingLocation = await repository.GetByIdAsync(id);
        if (existingLocation == null)
            return false;

        await repository.DeleteAsync(existingLocation);
        return true;
    }
}