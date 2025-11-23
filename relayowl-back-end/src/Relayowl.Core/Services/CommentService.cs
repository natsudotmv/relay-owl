using Relayowl.Core.Entities;
using Relayowl.Core.Respositories;

namespace Relayowl.Core.Services;

public class CommentService(ICommentRepository repository) : ICommentService
{
    public async Task<Comment?> GetCommentByIdAsync(int id)
    {
        return await repository.GetByIdAsync(id);
    }

    public async Task<List<Comment>> GetAllCommentsAsync()
    {
        return await repository.GetAllAsync();
    }

    public async Task<Comment> CreateCommentAsync(Comment comment)
    {
        ArgumentNullException.ThrowIfNull(comment);

        await repository.AddAsync(comment);
        return comment;
    }

    public async Task<bool> UpdateCommentAsync(int id, Comment comment)
    {
        ArgumentNullException.ThrowIfNull(comment);

        var existingComment = await repository.GetByIdAsync(comment.Id);
        if (existingComment == null)
            return false;
        
        await repository.UpdateAsync(comment);
        return true;
    }

    public async Task<bool> DeleteCommentAsync(int id)
    {
        var existingComment = await repository.GetByIdAsync(id);
        if (existingComment == null)
            return false;

        await repository.DeleteAsync(existingComment);
        return true;
    }
}