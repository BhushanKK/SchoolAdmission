using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Entities;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;
using static SchoolAdmission.Domain.Utils.CommanEnums;

namespace SchoolAdmission.Infrastructure.Repositories;

public class SubjectMasterRepository(ApplicationDbContext context) : ISubjectMasterRepository
{
    public async Task<List<SubjectMaster>> GetAllAsync(CancellationToken cancellationToken)
        => await context.Subjects
            .AsNoTracking()
            .ToListAsync(cancellationToken);

    public async Task<SubjectMaster?> GetByIdAsync(int id, CancellationToken cancellationToken)
        => await context.Subjects
            .FindAsync(new object[] { id }, cancellationToken);

    public async Task AddAsync(SubjectMaster subject, CancellationToken cancellationToken)
        => await context.Subjects.AddAsync(subject, cancellationToken);

    public async Task UpdateAsync(SubjectMaster subject, CancellationToken cancellationToken)
        => context.Subjects.Update(subject);

    public async Task DeleteAsync(SubjectMaster subject, CancellationToken cancellationToken)
        => context.Subjects.Remove(subject);

    public async Task<bool> IsExistsAsync(string subjectName, OperationType operation, int? subjectId, CancellationToken cancellationToken)
    {
        if (operation is OperationType.Create)
            return await context.Subjects
                .AnyAsync(x => x.SubjectName!.ToLower() == subjectName.ToLower(), cancellationToken);

        else if (operation is OperationType.Update)
            return await context.Subjects
                .AnyAsync(x => x.SubjectName!.ToLower() == subjectName.ToLower() && x.SubjectId != subjectId, cancellationToken);

        return false;
    }
}