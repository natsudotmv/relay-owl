using Microsoft.AspNetCore.Mvc;
using Relayowl.Core.Entities;
using Relayowl.Core.Services;

namespace Relayowl.Api.Controllers
{
    [Route("api/department")]
    [ApiController]
    public class DepartmentController(IDepartmentService service) : ControllerBase
    {
        // GET: api/department
         [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            var departments = await service.GetAllDepartmentsAsync();
            return Ok(departments);
        }

        // GET: api/department/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            var department = await service.GetDepartmentByIdAsync(id);
            if (department == null)
                return NotFound();
            return Ok(department);
        }

        // POST: api/department
        [HttpPost]
        public async Task<ActionResult<Department>> CreateDepartment([FromBody] Department department)
        {
            var created = await service.CreateDepartmentAsync(department);
            return CreatedAtAction(nameof(GetDepartment), new { id = created.Id }, created);
        }

        // PUT: api/department/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] Department department)
        {
            if(id != department.Id)
                return BadRequest("ID mismatch");
            
            var updated = await service.UpdateDepartmentAsync(department);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/department/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var deleted = await service.DeleteDepartmentAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
