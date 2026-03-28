using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;
using static SchoolAdmission.Domain.Utils.CommanEnums;

namespace SchoolAdmission.Infrastructure.Repositories;

public class CategoryMasterRepository(ApplicationDbContext context) : ICategoryMasterRepository
{
    public async Task<List<CategoryMaster>> GetAllAsync(CancellationToken cancellationToken)
        => await context.CategoryMasters
            .AsNoTracking()
            .ToListAsync(cancellationToken);

    public async Task<CategoryMaster?> GetByIdAsync(int id, CancellationToken cancellationToken)
        => await context.CategoryMasters
            .FirstOrDefaultAsync(x => x.categoryId == id, cancellationToken);

    public async Task AddAsync(CategoryMaster category, CancellationToken cancellationToken)
        => await context.CategoryMasters.AddAsync(category, cancellationToken);

    public Task Update(CategoryMaster category, CancellationToken cancellationToken)
    {
        context.CategoryMasters.Update(category);
        return Task.CompletedTask;
    }

    public Task Delete(CategoryMaster category, CancellationToken cancellationToken)
    {
        context.CategoryMasters.Remove(category);
        return Task.CompletedTask;
    }

    public async Task<bool> IsExistsAsync(string Category, OperationType  operation, int? CategoryId, CancellationToken cancellationToken)
    {
        if (operation == OperationType.Create)
            return await context.CategoryMasters.AnyAsync(x => x.Category.ToLower() == Category.ToLower(), cancellationToken);
        
        else if (operation == OperationType.Update)
            return await context.CategoryMasters.AnyAsync(x => x.Category.ToLower() == Category.ToLower() && x.categoryId != CategoryId, cancellationToken);

        return false;
    }

}
