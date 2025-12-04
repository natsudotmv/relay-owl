using Microsoft.EntityFrameworkCore;
using Relayowl.Core.Entities;
using Relayowl.Core.Respositories;
using Relayowl.Infrastructure.Data;

namespace Relayowl.Infrastructure.Repositories;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public async Task<DomainUser?> GetByIdAsync(int id)
    {
        return await context.DomainUsers.FindAsync(id);
    }

    public async Task<List<DomainUser>> GetAllAsync()
    {
        return await context.DomainUsers.ToListAsync();
    }

    public async Task AddAsync(DomainUser domainUser)
    {
        ArgumentNullException.ThrowIfNull(domainUser);

        await context.DomainUsers.AddAsync(domainUser);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(DomainUser domainUser)
    {
        ArgumentNullException.ThrowIfNull(domainUser);
        
        context.DomainUsers.Update(domainUser);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(DomainUser domainUser)
    {
        ArgumentNullException.ThrowIfNull(domainUser);
        
        context.DomainUsers.Remove(domainUser);
        await context.SaveChangesAsync();
    }
}