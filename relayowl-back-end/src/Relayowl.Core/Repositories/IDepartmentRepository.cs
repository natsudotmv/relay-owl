using Relayowl.Core.Entities;

namespace Relayowl.Core.Respositories;

public interface IDepartmentRepository
{
    Task<Department?> GetByIdAsync(int id);
    Task<List<Department>> GetAllAsync();
    Task AddAsync(Department department);
    Task UpdateAsync(Department department);
    Task DeleteAsync(Department department);
}