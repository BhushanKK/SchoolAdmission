using SchoolAdmission.Domain.Dtos;

public interface IStudentAddressesRepository
{
    Task <int> SaveStudentAddressesAsync(StudentAddressesDto dto, CancellationToken ct);
}

