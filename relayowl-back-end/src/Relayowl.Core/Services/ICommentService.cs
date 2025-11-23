using Relayowl.Core.Entities;

namespace Relayowl.Core.Services;

public interface ICommentService
{
    Task<Comment?> GetCommentByIdAsync(int id);
    Task<List<Comment>> GetAllCommentsAsync();
    Task<Comment> CreateCommentAsync(Comment comment);
    Task<bool> UpdateCommentAsync(int id, Comment comment);
    Task<bool> DeleteCommentAsync(int id);
}