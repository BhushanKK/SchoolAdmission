using SchoolAdmission.Domain.Entities;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Infrastructure.Repositories;

public class StudentDetailsRepository(ApplicationDbContext context) : IStudentDetailsRepository
{
    public async Task AddAsync(StudentDetails student,CancellationToken cancellationToken) 
    {
        await context.StudentDetails.AddAsync(student,cancellationToken);
    }

    public async Task<StudentDetails?> GetByIdAsync(Guid studentId, CancellationToken cancellationToken)
        => await context.StudentDetails
            .FindAsync(new object[] { studentId }, cancellationToken);
}