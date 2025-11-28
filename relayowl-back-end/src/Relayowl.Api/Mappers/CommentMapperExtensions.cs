using Relayowl.Api.DTOs.Comment;
using Relayowl.Core.Entities;

namespace Relayowl.Api.Mappers;

public static class CommentMapperExtensions
{
    public static ReadCommentDto ToReadCommentDto(this Core.Entities.Comment comment)
    {
        return new ReadCommentDto
        {
            Id = comment.Id,
            Message = comment.Message,
            TicketId = comment.TicketId,
            UserId = comment.UserId,
            CreatedAt = comment.CreatedAt
        };
    }
    
    public static Comment ToCreateCommentEntity(this CreateCommentDto dto)
    {
        return new Comment()
        {
            Message = dto.Message,
            TicketId = dto.TicketId,
            UserId = dto.UserId
        };
    }
    
    public static void UpdateComment(this Comment comment, UpdateCommentDto dto)
    {
        comment.Message = dto.Message;
    }
}