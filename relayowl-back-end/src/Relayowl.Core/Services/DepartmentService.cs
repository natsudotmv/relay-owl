using Relayowl.Core.Entities;
using Relayowl.Core.Respositories;

namespace Relayowl.Core.Services;

public class DepartmentService(IDepartmentRepository repository) : IDepartmentService
{
    

    // Get a department by ID
    public async Task<Department?> GetDepartmentByIdAsync(int id)
    {
        return await repository.GetByIdAsync(id);
    }

    // Get all departments
    public async Task<List<Department>> GetAllDepartmentsAsync()
    {
        return await repository.GetAllAsync();
    }

    // Create a new department
    public async Task<Department> CreateDepartmentAsync(Department department)
    {
        ArgumentNullException.ThrowIfNull(department);

        await repository.AddAsync(department);
        return department;
    }

    // Update an existing department
    public async Task<bool> UpdateDepartmentAsync(int id, Department department)
    {
        ArgumentNullException.ThrowIfNull(department);

        var existingDepartment = await repository.GetByIdAsync(department.Id);
        if (existingDepartment == null)
            return false;

        await repository.UpdateAsync(department);
        return true;
    }

    // Delete a department by ID
    public async Task<bool> DeleteDepartmentAsync(int id)
    {
        var existingDepartment = await repository.GetByIdAsync(id);
        if (existingDepartment == null)
            throw new KeyNotFoundException($"Department with Id {id} not found.");

        await repository.DeleteAsync(existingDepartment);
        return true;
    }
}