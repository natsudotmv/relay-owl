using Relayowl.Infrastructure.Data;
using Relayowl.Core.Respositories;
using Microsoft.EntityFrameworkCore;
using Relayowl.Core.Entities;

namespace Relayowl.Infrastructure.Repositories;

public class DepartmentRepository(AppDbContext context) : IDepartmentRepository
{
    public async Task<Department?> GetByIdAsync(int id)
    {
        return await context.Departments.FindAsync(id);
    }
    
    public async Task<List<Department>> GetAllAsync()
    {
        return await context.Departments.ToListAsync();
    }

    public async Task AddAsync(Department department)
    {
        if (department == null)
            throw new ArgumentNullException(nameof(department));

        await context.Departments.AddAsync(department);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Department department)
    {
        if (department == null)
            throw new ArgumentNullException(nameof(department));

        context.Departments.Update(department);
        await context.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(Department department)
    {
        if (department == null)
            throw new ArgumentNullException(nameof(department));

        context.Departments.Remove(department);
        await context.SaveChangesAsync();
    }
    
    public async Task<bool> ExistsAsync(int id)
    {
        return await context.Departments.AnyAsync(d => d.Id == id);
    }
}