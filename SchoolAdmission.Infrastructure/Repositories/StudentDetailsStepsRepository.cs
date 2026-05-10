using SchoolAdmission.Domain.Entities;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Infrastructure.Repositories;

public class StudentDetailsStepsRepository(ApplicationDbContext context) : IStudentDetailsStepsRepository
{
    public async Task<int> AddAsync(StudentDetailsStep entity, CancellationToken cancellationToken)
    {
        await context.StudentDetailsSteps.AddAsync(entity, cancellationToken);
        return await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<int> UpdateAsync(Guid studentId, StudentDetailsStep entity, CancellationToken cancellationToken)
    {
        var existingEntity = await context.StudentDetailsSteps.FindAsync(new object[] { studentId }, cancellationToken);
        if (existingEntity == null)
            throw new InvalidOperationException("Student details step not found");

        context.Entry(existingEntity).CurrentValues.SetValues(entity);
        return await context.SaveChangesAsync(cancellationToken);
    }
}