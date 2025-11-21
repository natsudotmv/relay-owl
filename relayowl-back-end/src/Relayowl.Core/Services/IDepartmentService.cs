using Relayowl.Core.Entities;

namespace Relayowl.Core.Services;

public interface IDepartmentService
{
    Task<Department?> GetDepartmentByIdAsync(int id);
    Task<List<Department>> GetAllDepartmentsAsync();
    Task<Department> CreateDepartmentAsync(Department department);
    Task<bool>  UpdateDepartmentAsync(int id, Department department);
    Task<bool> DeleteDepartmentAsync(int id);
}