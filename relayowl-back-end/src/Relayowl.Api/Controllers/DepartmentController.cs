using Microsoft.AspNetCore.Mvc;
using Relayowl.Api.DTOs.Department;
using Relayowl.Api.Mappers;
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
        public async Task<ActionResult<List<Department>>> GetDepartments()
        {
            var departments = await service.GetAllDepartmentsAsync();
            var dtoList = departments.Select(d => d.ToReadDepartmentDto()).ToList();
            return Ok(dtoList);
        }

        // GET: api/department/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            var department = await service.GetDepartmentByIdAsync(id);
            return Ok(department?.ToReadDepartmentDto());
        }

        // POST: api/department
        [HttpPost]
        public async Task<ActionResult<ReadDepartmentDto>> CreateDepartment([FromBody] CreateDepartmentDto dto)
        {
            var department = dto.ToCreateDepartmentEntity();
            await service.CreateDepartmentAsync(department);
            var readDto = department.ToReadDepartmentDto();
            return CreatedAtAction(nameof(GetDepartment), new { id = readDto.Id }, department.ToReadDepartmentDto());
        }

        // PUT: api/department/{id}
        [HttpPut("{id:int}")]
        public async Task<ActionResult<ReadDepartmentDto>> UpdateDepartment(int id, [FromBody] UpdateDepartmentDto updateDepartmentDto)
        {
            var departmentToUpdate = updateDepartmentDto.ToUpdateDepartmentEntity();
            var updatedLocation = await service.UpdateDepartmentAsync(id, departmentToUpdate);
            
            return Ok(updatedLocation);
        }

        // DELETE: api/department/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var deleted = await service.DeleteDepartmentAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
