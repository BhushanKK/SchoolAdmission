using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Infrastructure.Interfaces;
public interface IFeesStructureDetailsRepository
{
    Task<List<FeesStructureQueryDto>> GetAllAsync(CancellationToken cancellationToken);

    Task<FeesStructureDetails?> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task AddAsync(FeesStructureDetails fee, CancellationToken cancellationToken);

    Task UpdateAsync(FeesStructureDetails fee, CancellationToken cancellationToken);

    Task DeleteAsync(FeesStructureDetails fee, CancellationToken cancellationToken);
}
