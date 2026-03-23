using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Infrastructure.Interfaces;

public interface IStudentAddressesRepository
{
    Task<int> SaveStudentAddressesAsync(StudentAddressesDto entity, CancellationToken cancellationToken);
}

