using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Domain.Entities;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;
using static SchoolAdmission.Domain.Utils.CommanEnums;

namespace SchoolAdmission.Infrastructure.Repositories;

public class StudentSubjectChoiceRepository(ApplicationDbContext context)
    : IStudentSubjectChoiceRepository
{
    public async Task<List<StudentSubjectChoice>> GetAllAsync(CancellationToken cancellationToken)
        => await context.studentSubjectChoice
            .AsNoTracking()
            .ToListAsync(cancellationToken);

    public async Task<StudentSubjectChoice?> GetByIdAsync(int id, CancellationToken cancellationToken)
        => await context.studentSubjectChoice
            .FindAsync(new object[] { id }, cancellationToken);

    public async Task AddAsync(StudentSubjectChoice studentSubjectChoice, CancellationToken cancellationToken)
        => await context.studentSubjectChoice.AddAsync(studentSubjectChoice, cancellationToken);

    public async Task UpdateAsync(StudentSubjectChoice studentSubjectChoice, CancellationToken cancellationToken)
        => context.studentSubjectChoice.Update(studentSubjectChoice);

    public async Task DeleteAsync(StudentSubjectChoice studentSubjectChoice, CancellationToken cancellationToken)
        => context.studentSubjectChoice.Remove(studentSubjectChoice);

    public async Task<bool> IsExistsAsync(Guid studentId,int subjectId,OperationType operation,int ChoiceId,
    CancellationToken cancellationToken)
    {
        if (operation is OperationType.Create)
            return await context.studentSubjectChoice.AnyAsync(x =>
                x.StudentId == studentId &&
                x.SubjectId == subjectId,
                cancellationToken);

        else if (operation is OperationType.Update)
            return await context.studentSubjectChoice.AnyAsync(x =>
                x.StudentId == studentId &&
                x.SubjectId == subjectId &&
                x.ChoiceId != ChoiceId,
                cancellationToken);

        return false;
    }
}