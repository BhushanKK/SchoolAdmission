using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Infrastructure.Data;

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

    public async Task<List<CasteMasterDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var query = from caste in context.CasteMasters
                    join category in context.CategoryMasters
                        on caste.CategoryId equals category.categoryId
                    select new CasteMasterDto
                    {
                        CasteId = caste.CasteId,
                        CategoryId = caste.CategoryId,
                        CategoryName = category.Category,
                        Caste = caste.Caste
                    };

        return await query.AsNoTracking().ToListAsync(cancellationToken);
    }
}