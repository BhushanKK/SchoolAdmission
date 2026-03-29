

namespace SchoolAdmission.Infrastructure.Interfaces;
public interface IStudentDetailsViewRepository
{
    Task<List<StudentDetailsView>> GetAllAsync(CancellationToken cancellationToken);
}