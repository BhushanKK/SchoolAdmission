
using SchoolAdmission.Domain.ViewModels;

namespace SchoolAdmission.Infrastructure.Interfaces;
public interface IStudentDetailsViewRepository
{
    Task<List<StudentDetailsView>> GetAllAsync(CancellationToken cancellationToken);
    Task<StudentDetailsView?> GetStudentReportAsync(Guid studentId, CancellationToken cancellationToken);
}