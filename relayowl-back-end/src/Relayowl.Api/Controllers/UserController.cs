using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Relayowl.Api.DTOs.User;
using Relayowl.Api.Mappers;
using Relayowl.Core.Interfaces;

namespace Relayowl.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController(IUserService service) : ControllerBase
    {
        // GET: api/users/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await service.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }
        
        // GET: api/users
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await service.GetAllUsersAsync();
            return Ok(users);
        }
        
        // POST: api/users
        [HttpPost]
        public async Task<ActionResult<ReadUserDto>> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            var user = createUserDto.ToCreateUserEntity();
            await service.CreateUserAsync(user);
            var createdUserDto = user.ToReadUserDto();
            return CreatedAtAction(nameof(GetUserById), new { id = createdUserDto.Id }, createdUserDto);
        }
        
        // PUT: api/user{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] Core.Entities.User user)
        {
            var updatedTicket = await service.UpdateUserAsync(id, user);
            if (!updatedTicket)
            {
                return NotFound(); // 404 if entity doesn't exist
            }
            return NoContent(); // 204 No Content if successful
        }
        
        // DELETE: api/user{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var deleted = await service.DeleteUserAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
