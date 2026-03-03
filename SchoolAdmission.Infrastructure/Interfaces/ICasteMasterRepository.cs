using SchoolAdmission.Domain;

namespace SchoolAdmission.Application.Common.Interfaces;

public interface ICasteMasterRepository
{
    Task<List<CasteMaster>> GetAllAsync();
    Task<CasteMaster?> GetByIdAsync(int id);
    Task AddAsync(CasteMaster caste);
    void Update(CasteMaster caste);
    void Delete(CasteMaster caste);
    Task SaveChangesAsync();
}