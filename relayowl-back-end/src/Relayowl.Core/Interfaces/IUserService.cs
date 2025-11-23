using Relayowl.Core.Entities;

namespace Relayowl.Core.Interfaces;

public interface IUserService
{
    Task<User?> GetUserByIdAsync(int id);
    Task<List<User>> GetAllUsersAsync();
    Task<User> CreateUserAsync(User user);
    Task<bool> UpdateUserAsync(int id, User user);
    Task<bool> DeleteUserAsync(int id);
}