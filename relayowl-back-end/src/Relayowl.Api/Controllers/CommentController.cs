using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Relayowl.Api.DTOs.Comment;
using Relayowl.Api.Mappers;
using Relayowl.Core.Services;

namespace Relayowl.Api.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentController(ICommentService service) : ControllerBase
    {
        // GET: api/comment/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ticket = await service.GetCommentByIdAsync(id);
            
            return Ok(ticket?.ToReadCommentDto());
        }
        
        // GET: api/comment
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await service.GetAllCommentsAsync();
            var ticketDtos = comments.Select(t => t.ToReadCommentDto()).ToList();
            return Ok(ticketDtos);
        }
        
        // POST: api/comment
        [HttpPost]
        public async Task<ActionResult<ReadCommentDto>> Create([FromBody] CreateCommentDto createCommentDto)
        {
            var comment = createCommentDto.ToCreateCommentEntity();
            await service.CreateCommentAsync(comment);
            var createdTicket = comment.ToReadCommentDto();
            return CreatedAtAction(nameof(GetById), new { id = createdTicket.Id }, createdTicket);
        }
        
        // PUT: api/comment/{id}
        [HttpPut("{id:int}")]
        public async Task<ActionResult<ReadCommentDto>> Update(int id, [FromBody] UpdateCommentDto updateCommentDto)
        {
            var commentToUpdate = await service.GetCommentByIdAsync(id);
            if (commentToUpdate == null)
                return NotFound(); // 404 if entity doesn't exist
            
            commentToUpdate.Message = updateCommentDto.Message;
            
            await service.UpdateCommentAsync(id, commentToUpdate);
            return NoContent(); // 204 No Content if successful
        }
        
        // DELETE: api/comment/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await service.DeleteCommentAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
