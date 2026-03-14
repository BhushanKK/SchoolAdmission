using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Infrastructure.Repositories;

public class CasteMasterRepository(ApplicationDbContext context) : ICasteMasterRepository
{
    public async Task<CasteMaster?> GetByIdAsync(int id, CancellationToken cancellationToken)
        => await context.CasteMasters
            .FindAsync(new object[] { id }, cancellationToken);

    public async Task AddAsync(CasteMaster caste, CancellationToken cancellationToken)
        => await context.CasteMasters.AddAsync(caste, cancellationToken);

    public async Task Update(CasteMaster caste, CancellationToken cancellationToken)
        => context.CasteMasters.Update(caste);

    public async Task Delete(CasteMaster caste, CancellationToken cancellationToken)
        => context.CasteMasters.Remove(caste);

    public async Task<List<CasteMasterQueryDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var query = from caste in context.CasteMasters
                    join category in context.CategoryMasters
                        on caste.CategoryId equals category.categoryId
                    select new CasteMasterQueryDto
                    {
                        CasteId = caste.CasteId,
                        CategoryId = caste.CategoryId,
                        Caste = caste.Caste
                    };

        return await query.AsNoTracking().ToListAsync(cancellationToken);
    }
    public async Task<CasteMasterQueryDto?> GetByIdWithCategoryAsync(int id, CancellationToken cancellationToken)
    {
        var query = from caste in context.CasteMasters
                    join category in context.CategoryMasters
                        on caste.CategoryId equals category.categoryId
                    where caste.CasteId == id
                    select new CasteMasterQueryDto
                    {
                        CasteId = caste.CasteId,
                        CategoryId = caste.CategoryId,
                        Caste = caste.Caste
                    };

        return await query.AsNoTracking().FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<bool> IsExistsAsync(string caste, CancellationToken cancellationToken)
    {
        return await context.CasteMasters
        .AnyAsync(x => x.Caste == caste, cancellationToken);
    }
}