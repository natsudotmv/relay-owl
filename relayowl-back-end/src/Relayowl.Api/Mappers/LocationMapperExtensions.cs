using Relayowl.Api.DTOs.Location;
using Relayowl.Core.Entities;

namespace Relayowl.Api.Mappers;

public static class LocationMapperExtensions
{
    public static ReadLocationDto ToReadLocationDto(this Core.Entities.Location location)
    {
        return new ReadLocationDto
        {
            Id = location.Id,
            Name = location.Name
        };
    }
    
    public static Location ToCreateLocationEntiy(this CreateLocationDto dto)
    {
        return new Location()
        {
            Name = dto.Name
        };
    }
    
    public static void UpdateLocation(this Location location, UpdateLocationDto dto)
    {
        location.Name = dto.Name;
    }
}