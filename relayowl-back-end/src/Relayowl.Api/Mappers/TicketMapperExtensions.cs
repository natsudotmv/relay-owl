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
            Status = ticket.Status,
            CreatedAt = ticket.CreatedAt,
            UpdatedAt = ticket.UpdatedAt
        };
    }
    
    public static Core.Entities.Ticket ToCreateTicketEntity(this CreateTicketDto dto)
    {
        return new Core.Entities.Ticket()
        {
            Title = dto.Title,
            Description = dto.Description,
            Status = dto.Status
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