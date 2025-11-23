using Relayowl.Core.Entities;
using Relayowl.Core.Interfaces;
using Relayowl.Core.Respositories;

namespace Relayowl.Infrastructure.Services;

public class UserService(IUserRepository repository) : IUserService
{
    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await repository.GetByIdAsync(id);
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        return await repository.GetAllAsync();
    }

    public async Task<User> CreateUserAsync(User user)
    {
        ArgumentNullException.ThrowIfNull(user);

        await repository.AddAsync(user);
        return user;
    }

    public async Task<bool> UpdateUserAsync(int id, User user)
    {
        ArgumentNullException.ThrowIfNull(user);

        var existingUser = await repository.GetByIdAsync(user.Id);
        if (existingUser == null)
            return false;
        
        await repository.UpdateAsync(user);
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