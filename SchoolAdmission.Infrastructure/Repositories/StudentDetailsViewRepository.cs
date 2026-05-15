using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Domain.ViewModels;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Infrastructure.Repositories;

public class StudentDetailsViewRepository(ApplicationDbContext context) : IStudentDetailsViewRepository
{
    public async Task<List<StudentDetailsView>> GetAllAsync(CancellationToken cancellationToken)
        => await context.StudentDetailsView
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    
     public async Task<StudentDetailsView?> GetStudentReportAsync(Guid studentId, CancellationToken cancellationToken)
        => await context.StudentDetailsView
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.StudentId == studentId, cancellationToken);
        
}