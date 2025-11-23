using Microsoft.EntityFrameworkCore;
using Relayowl.Core.Entities;
using Relayowl.Core.Respositories;
using Relayowl.Infrastructure.Data;

namespace Relayowl.Infrastructure.Repositories;

public class CommentRepository(AppDbContext context) : ICommentRepository
{
    public async Task<Comment?> GetByIdAsync(int id)
    {
        return await context.Comments.FindAsync(id);
    }

    public async Task<List<Comment>> GetAllAsync()
    {
        return await context.Comments.ToListAsync();
    }

    public async Task AddAsync(Comment location)
    {
        ArgumentNullException.ThrowIfNull(location);

        await context.Comments.AddAsync(location);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Comment comment)
    {
        ArgumentNullException.ThrowIfNull(comment);
        
        context.Comments.Update(comment);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Comment comment)
    {
        ArgumentNullException.ThrowIfNull(comment);
        
        context.Comments.Remove(comment);
        await context.SaveChangesAsync();
    }
}