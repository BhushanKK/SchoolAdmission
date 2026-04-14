using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;
using static SchoolAdmission.Domain.Utils.CommanEnums;

namespace SchoolAdmission.Infrastructure.Repositories;

public class SchoolMasterRepository(ApplicationDbContext context) : ISchoolMasterRepository
{
    public async Task<List<SchoolMaster>> GetAllAsync(int commiteeId, CancellationToken cancellationToken)
    {
        var query = from school in context.SchoolMasters.AsNoTracking()
                    join committee in context.CommiteMasters.AsNoTracking()
                    on school.CommiteeId equals committee.CommiteeId
                    select new SchoolMaster
                    {
                        SchoolId = school.SchoolId,
                        SchoolName = school.SchoolName,
                        CommiteeId = school.CommiteeId,
                        Status = school.Status,
                        LogoPath = school.LogoPath,
                        CommitteeName = committee.CommiteeName
                    };
        if (commiteeId != 0)
            query = query.Where(s => s.CommiteeId == commiteeId);
            
        return await query.ToListAsync(cancellationToken);
    }

    public async Task<SchoolMaster?> GetByIdAsync(int id, CancellationToken cancellationToken)
        => await context.SchoolMasters
            .FindAsync(new object[] { id }, cancellationToken);

    public async Task AddAsync(SchoolMaster school, CancellationToken cancellationToken)
        => await context.SchoolMasters.AddAsync(school, cancellationToken);

    public async Task UpdateAsync(SchoolMaster school, CancellationToken cancellationToken)
        => context.SchoolMasters.Update(school);

    public async Task DeleteAsync(SchoolMaster school, CancellationToken cancellationToken)
        => context.SchoolMasters.Remove(school);

    public async Task<bool> IsExistsAsync(string SchoolName, OperationType operation, int? SchoolId, CancellationToken cancellationToken)
    {
        if (operation == OperationType.Create)
            return await context.SchoolMasters.AnyAsync(x => x.SchoolName!.ToLower() == SchoolName.ToLower(), cancellationToken);

        else if (operation == OperationType.Update)
            return await context.SchoolMasters.AnyAsync(x => x.SchoolName!.ToLower() == SchoolName.ToLower() && x.SchoolId != SchoolId, cancellationToken);

        return false;
    }
}
