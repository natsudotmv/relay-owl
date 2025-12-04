using Relayowl.Core.Entities;

namespace Relayowl.Infrastructure.Identity;

public static class UserMapper
{
    public static DomainUser ToDomainUser(AppUser appUser)
    {
        return new DomainUser
        {
            Id = int.Parse(appUser.Id),
            FullName = appUser.FullName,
            Email = appUser.Email!,
            PasswordHash = appUser.PasswordHash!
        };
    }
    
    public static AppUser ToAppUser(DomainUser domainUser)
    {
        return new AppUser
        {
            Id = domainUser.Id.ToString(),
            FullName = domainUser.FullName,
            Email = domainUser.Email,
            UserName = domainUser.Email,
            PasswordHash = domainUser.PasswordHash
        };
    }
}