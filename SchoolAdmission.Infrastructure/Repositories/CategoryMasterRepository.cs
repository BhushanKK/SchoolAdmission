using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;

namespace SchoolAdmission.Infrastructure.Repositories;

public class CategoryMasterRepository(ApplicationDbContext context) : ICategoryMasterRepository
{
    public async Task<List<CategoryMaster>> GetAllAsync(CancellationToken cancellationToken)
        => await context.CategoryMasters
            .AsNoTracking()
            .ToListAsync(cancellationToken);

    public async Task<CategoryMaster?> GetByIdAsync(int id, CancellationToken cancellationToken)
        => await context.CategoryMasters
            .FindAsync(new object[] { id }, cancellationToken);

    public async Task AddAsync(CategoryMaster category, CancellationToken cancellationToken)
        => await context.CategoryMasters.AddAsync(category, cancellationToken);

    public async Task Update(CategoryMaster category, CancellationToken cancellationToken)
        => context.CategoryMasters.Update(category);

    public async Task Delete(CategoryMaster category, CancellationToken cancellationToken)
        => context.CategoryMasters.Remove(category);
}