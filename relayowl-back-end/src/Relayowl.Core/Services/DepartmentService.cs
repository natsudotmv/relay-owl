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
        if (department == null)
            throw new ArgumentNullException(nameof(department));

        await repository.AddAsync(department);
        return department;
    }

    // Update an existing department
    public async Task<bool> UpdateDepartmentAsync(Department department)
    {
        if (department == null)
            throw new ArgumentNullException(nameof(department));

        var existing = await repository.GetByIdAsync(department.Id);
        if (existing == null)
            return false;

        await repository.UpdateAsync(department);
        return true;
    }

    // Delete a department by ID
    public async Task<bool> DeleteDepartmentAsync(int id)
    {
        var existing = await repository.GetByIdAsync(id);
        if (existing == null)
            throw new KeyNotFoundException($"Department with Id {id} not found.");

        await repository.DeleteAsync(existing);
        return true;
    }
}