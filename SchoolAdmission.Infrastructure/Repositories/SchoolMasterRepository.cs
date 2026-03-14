using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Infrastructure.Repositories;

public class SchoolMasterRepository(ApplicationDbContext context) : ISchoolMasterRepository
{
    
    public async Task<SchoolMasterQueryDto?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await context.SchoolMasters
            .Where(s => s.SchoolId == id)
            .Select(school => new SchoolMasterQueryDto
            {
                SchoolId = school.SchoolId,
                SchoolName = school.SchoolName,
                CommiteeId = school.CommiteeId
            })
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<SchoolMaster?> GetEntityByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await context.SchoolMasters
            .FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task<List<SchoolMasterQueryDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await context.SchoolMasters
            .Select(school => new SchoolMasterQueryDto
            {
                SchoolId = school.SchoolId,
                SchoolName = school.SchoolName,
                CommiteeId = school.CommiteeId
            })
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(SchoolMaster school, CancellationToken cancellationToken)
    {
        await context.SchoolMasters.AddAsync(school, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(SchoolMaster school, CancellationToken cancellationToken)
    {
        context.SchoolMasters.Update(school);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(SchoolMaster school, CancellationToken cancellationToken)
    {
        context.SchoolMasters.Remove(school);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> IsExistsAsync(string SchoolName, CancellationToken cancellationToken)
    {
        return await context.SchoolMasters
        .AnyAsync(x => x.SchoolName == SchoolName, cancellationToken);
    }
}