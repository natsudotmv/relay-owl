using Relayowl.Api.DTOs.Department;
using Relayowl.Core.Entities;

namespace Relayowl.Api.Mappers;

public static class DepartmentMapperExtensions
{
    public static ReadDepartmentDto ToReadDepartmentDto(this Department department)
    {
        return new ReadDepartmentDto()
        {
            Id = department.Id,
            Name = department.Name
        };
    }
    
    public static Department ToCreateDepartmentEntity(this CreateDepartmentDto dto)
    {
        return new Department()
        {
            Name = dto.Name
        };
    }
    
    public static void UpdateDepartment(this Department department, UpdateDepartmentDto dto)
    {
        department.Name = dto.Name;
    }
}