using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Domain.Entities;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Infrastructure.Repositories;

public class StudentDetailsRepository(ApplicationDbContext context) : IStudentDetailsRepository
{
    public async Task<List<StudentDetails>> GetAllAsync(CancellationToken cancellationToken)
        => await context.StudentDetails
            .AsNoTracking()
            .ToListAsync(cancellationToken);

    public async Task<StudentDetails?> GetByIdAsync(Guid studentId, CancellationToken cancellationToken)
        => await context.StudentDetails
            .FindAsync(new object[] { studentId }, cancellationToken);

    public async Task<int> AddAsync(StudentDetails entity, CancellationToken cancellationToken = default)
    {
        await context.StudentDetails.AddAsync(entity, cancellationToken);
        return await context.SaveChangesAsync(cancellationToken);
    }

    // Update
    public async Task<int> UpdateAsync(StudentDetails entity, CancellationToken cancellationToken = default)
    {
        context.StudentDetails.Update(entity);
        return await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<int> DeleteAsync(Guid studentId, CancellationToken cancellationToken = default)
    {
        var entity = await context.StudentDetails.FindAsync(new object[] { studentId }, cancellationToken);
        if (entity != null)
        {
            context.StudentDetails.Remove(entity);
            return await context.SaveChangesAsync(cancellationToken);
        }
        return 0;
    }
}