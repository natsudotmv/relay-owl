using Relayowl.Core.Entities;

namespace Relayowl.Core.Respositories;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id);
    Task<List<User>> GetAllAsync();
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(User user);
}