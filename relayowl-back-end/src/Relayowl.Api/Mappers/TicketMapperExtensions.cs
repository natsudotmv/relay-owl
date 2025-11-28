using Relayowl.Api.DTOs.Ticket;

namespace Relayowl.Api.Mappers;

public static class TicketMapperExtensions
{
    public static ReadTicketDto ToReadTicketDto(this Core.Entities.Ticket ticket)
    {
        return new ReadTicketDto
        {
            Id = ticket.Id,
            Title = ticket.Title,
            Description = ticket.Description,
            
            Priority = ticket.Priority,
            Status = ticket.Status,
            
            DepartmentId = ticket.DepartmentId,
            DepartmentName = ticket.Department?.Name ?? string.Empty,
            
            LocationId = ticket.LocationId,
            LocationName = ticket.Location?.Name ?? string.Empty,
            
            CreatedById = ticket.CreatedById,
            CreatedByName = ticket.CreatedBy?.FullName ?? string.Empty,
            
            CreatedAt = ticket.CreatedAt,
            UpdatedAt = ticket.UpdatedAt,
            
            Comments = ticket.Comments
                .Select(c => c.ToReadCommentDto())
                .ToList()
        };
    }
    
    public static Core.Entities.Ticket ToCreateTicketEntity(this CreateTicketDto dto)
    {
        return new Core.Entities.Ticket()
        {
            Title = dto.Title,
            Description = dto.Description,
            
            Priority = dto.Priority,
            Status = dto.Status,
            
            DepartmentId = dto.DepartmentId,
            LocationId = dto.LocationId,
            CreatedById = dto.CreatedById,
            
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }
    
    public static Core.Entities.Ticket ToUpdateTicket(this UpdateTicketDto dto)
    {
        return new Core.Entities.Ticket()
        {
            Title = dto.Title,
            Description = dto.Description,
            Status = dto.Status
        };
    }
}