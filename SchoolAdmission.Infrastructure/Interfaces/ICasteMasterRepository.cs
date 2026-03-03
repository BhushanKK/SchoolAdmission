using SchoolAdmission.Domain;

namespace SchoolAdmission.Application.Common.Interfaces;

public interface ICasteMasterRepository
{
    Task<List<CasteMaster>> GetAllAsync();
    Task<CasteMaster?> GetByIdAsync(int id);
    Task AddAsync(CasteMaster caste);
    Task UpdateAsync(CasteMaster caste);
    Task DeleteAsync(CasteMaster caste);
    Task SaveChangesAsync();
}