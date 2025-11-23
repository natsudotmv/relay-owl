using Microsoft.AspNetCore.Mvc;
using Relayowl.Api.DTOs.Location;
using Relayowl.Api.Mappers;
using Relayowl.Core.Services;

namespace Relayowl.Api.Controllers
{
    [Route("api/locations")]
    [ApiController]
    public class LocationController(ILocationService service) : ControllerBase
    {
        // GET: api/location/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var location = await service.GetLocationByIdAsync(id);
            
            return Ok(location?.ToReadLocationDto());
        }
        
        // GET: api/location
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var locations = await service.GetAllLocationsAsync();
            var locationDtos = locations.Select(loc => loc.ToReadLocationDto()).ToList();
            return Ok(locationDtos);
        }
        
        // POST: api/location
        [HttpPost]
        public async Task<ActionResult<ReadLocationDto>> Create([FromBody] CreateLocationDto createLocationDto)
        {
            var location = createLocationDto.ToCreateLocationEntiy();
            await service.CreateLocationAsync(location);
            var readDto = location.ToReadLocationDto();
            return CreatedAtAction(nameof(GetById), new { id = readDto.Id },
                readDto);
        }
        
        // PUT: api/location/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateLocationDto updateLocationDto)
        {
            var locationToUpdate = updateLocationDto.ToUpdateLocation();
            // Service handles fetching, updating, and returns bool
            var updated = await service.UpdateLocationAsync(id, locationToUpdate);

            if (!updated)
                return NotFound(); // 404 if entity doesn't exist

            return NoContent(); // 204 No Content if successful
        }
        
        // DELETE: api/location/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await service.DeleteLocationAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}
