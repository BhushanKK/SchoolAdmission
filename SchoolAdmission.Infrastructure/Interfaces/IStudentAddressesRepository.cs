using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.Entities;

namespace SchoolAdmission.Infrastructure.Interfaces;
public interface IStudentAddressesRepository
{
    Task<StudentAddresses?> GetByStudentIdAsync(Guid studentId, CancellationToken cancellationToken);
    Task <int> SaveStudentAddressesAsync(StudentAddressesDto dto, CancellationToken ct);
}

