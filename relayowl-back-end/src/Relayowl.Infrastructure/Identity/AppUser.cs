using Microsoft.AspNetCore.Identity;

namespace Relayowl.Infrastructure.Identity;

public class AppUser : IdentityUser
{
    public string FullName { get; set; } = null!;
}