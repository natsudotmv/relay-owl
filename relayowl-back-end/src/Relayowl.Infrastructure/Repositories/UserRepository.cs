using Microsoft.EntityFrameworkCore;
using Relayowl.Core.Entities;
using Relayowl.Core.Respositories;
using Relayowl.Infrastructure.Data;

namespace Relayowl.Infrastructure.Repositories;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public async Task<User?> GetByIdAsync(int id)
    {
        return await context.Users.FindAsync(id);
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await context.Users.ToListAsync();
    }

    public async Task AddAsync(User user)
    {
        ArgumentNullException.ThrowIfNull(user);

        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        ArgumentNullException.ThrowIfNull(user);
        
        context.Users.Update(user);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(User user)
    {
        ArgumentNullException.ThrowIfNull(user);
        
        context.Users.Remove(user);
        await context.SaveChangesAsync();
    }
}