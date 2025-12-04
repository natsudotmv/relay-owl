using Relayowl.Core.Entities;

namespace Relayowl.Core.Respositories;

public interface IUserRepository
{
    Task<DomainUser?> GetByIdAsync(int id);
    Task<List<DomainUser>> GetAllAsync();
    Task AddAsync(DomainUser domainUser);
    Task UpdateAsync(DomainUser domainUser);
    Task DeleteAsync(DomainUser domainUser);
}