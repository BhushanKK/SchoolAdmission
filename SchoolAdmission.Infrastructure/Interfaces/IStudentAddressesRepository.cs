using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.Entities;

namespace SchoolAdmission.Infrastructure.Interfaces;

public interface IStudentAddressesRepository
{
    Task<int> SaveStudentAddressesAsync(StudentAddressesDto entity, CancellationToken cancellationToken);
}
