using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Relayowl.Api.DTOs.Account;
using Relayowl.Infrastructure.Identity;

namespace Relayowl.Api.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountController(UserManager<AppUser> userManager) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAccountDto createAccountDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                
                var appUser = new AppUser
                {
                    UserName = createAccountDto.Email,
                    Email = createAccountDto.Email,
                    FullName = createAccountDto.FullName
                };
                
                if(createAccountDto.Password is null)
                    return BadRequest("Password is required.");
                var createUser = await userManager.CreateAsync(appUser, createAccountDto.Password!);
                
                if (createUser.Succeeded)
                {
                    var roleResult = await userManager.AddToRoleAsync(appUser, "Staff");

                    if (roleResult.Succeeded)
                    {
                        return Ok(new { Message = "Account created successfully." });
                    }
                    else
                    {
                        return StatusCode(500, "Error assigning role to user.");
                    }
                }
                else
                {
                    return StatusCode(500);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}
