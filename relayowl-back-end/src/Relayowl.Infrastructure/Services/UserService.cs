using Relayowl.Core.Entities;
using Relayowl.Core.Interfaces;
using Relayowl.Core.Respositories;

namespace Relayowl.Infrastructure.Services;

public class UserService(IUserRepository repository) : IUserService
{
    public async Task<DomainUser?> GetUserByIdAsync(int id)
    {
        return await repository.GetByIdAsync(id);
    }

    public async Task<List<DomainUser>> GetAllUsersAsync()
    {
        return await repository.GetAllAsync();
    }

    public async Task<DomainUser> CreateUserAsync(DomainUser domainUser)
    {
        ArgumentNullException.ThrowIfNull(domainUser);

        await repository.AddAsync(domainUser);
        return domainUser;
    }

    public async Task<bool> UpdateUserAsync(int id, DomainUser domainUser)
    {
        ArgumentNullException.ThrowIfNull(domainUser);

        var existingUser = await repository.GetByIdAsync(domainUser.Id);
        if (existingUser == null)
            return false;
        
        await repository.UpdateAsync(domainUser);
        return true;
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var existingUser = await repository.GetByIdAsync(id);
        if (existingUser == null)
            return false;

        await repository.DeleteAsync(existingUser);
        return true;
    }
}