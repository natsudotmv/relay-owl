using Microsoft.AspNetCore.Mvc;
using Relayowl.Api.DTOs.Ticket;
using Relayowl.Api.Mappers;
using Relayowl.Core.Services;

namespace Relayowl.Api.Controllers
{
    [Route("api/ticket")]
    [ApiController]
    public class TicketController(ITicketService service) : ControllerBase
    {
        // GET: api/ticket/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ticket = await service.GetTicketByIdAsync(id);
            
            return Ok(ticket?.ToReadTicketDto());
        }
        
        // GET: api/ticket
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tickets = await service.GetAllTicketsAsync();
            var ticketDtos = tickets.Select(t => t.ToReadTicketDto()).ToList();
            return Ok(ticketDtos);
        }
        
        // POST: api/ticket
        [HttpPost]
        public async Task<ActionResult<ReadTicketDto>> Create([FromBody] CreateTicketDto createTicketDto)
        {
            var ticket = createTicketDto.ToCreateTicketEntity();
            await service.CreateTicketAsync(ticket);
            var createdTicket = ticket.ToReadTicketDto();
            return CreatedAtAction(nameof(GetById), new { id = createdTicket.Id }, createdTicket);
        }
        
        // PUT: api/ticket/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Core.Entities.Ticket ticket)
        {
            var updatedTicket = await service.UpdateTicketAsync(id, ticket);
            if (!updatedTicket)
            {
                return NotFound(); // 404 if entity doesn't exist
            }
            return NoContent(); // 204 No Content if successful
        }
        
        // DELETE: api/ticket/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await service.DeleteTicketAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
