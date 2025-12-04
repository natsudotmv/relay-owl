using Relayowl.Core.Entities;

namespace Relayowl.Core.Interfaces;

public interface IUserService
{
    Task<DomainUser?> GetUserByIdAsync(int id);
    Task<List<DomainUser>> GetAllUsersAsync();
    Task<DomainUser> CreateUserAsync(DomainUser domainUser);
    Task<bool> UpdateUserAsync(int id, DomainUser domainUser);
    Task<bool> DeleteUserAsync(int id);
}