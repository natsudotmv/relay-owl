using Relayowl.Core.Entities;

namespace Relayowl.Core.Respositories;

public interface ICommentRepository
{
    Task<Comment?> GetByIdAsync(int id);
    Task<List<Comment>> GetAllAsync();
    Task AddAsync(Comment comment);
    Task UpdateAsync(Comment comment);
    Task DeleteAsync(Comment comment);
}