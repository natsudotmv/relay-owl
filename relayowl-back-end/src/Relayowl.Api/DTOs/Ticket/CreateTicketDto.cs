using System.ComponentModel.DataAnnotations;
using Relayowl.Core.Entities;

namespace Relayowl.Api.DTOs.Ticket;

public class CreateTicketDto
{
    [Required]
    [MaxLength(50, ErrorMessage = "Title cannot exceed 50 characters.")]
    public string Title { get; set; } = null!;
    [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
    public string? Description { get; set; }
    
    public Priority Priority { get; set; }
    public TicketStatus Status { get; set; }
    
    [Range(1, int.MaxValue)]
    public int DepartmentId { get; set; }
    
    [Range(1, int.MaxValue)]
    public int LocationId { get; set; }
    
    [Range(1, int.MaxValue)]
    public int CreatedById { get; set; }
}