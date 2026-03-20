using SchoolAdmission.Domain;

namespace SchoolAdmission.Infrastructure.Interfaces;
public interface IFeesStructureDetailRepository
{
    Task<List<FeesStructureDetail>> GetAllAsync(CancellationToken cancellationToken);

    Task<FeesStructureDetail?> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task AddAsync(FeesStructureDetail fee, CancellationToken cancellationToken);

    Task UpdateAsync(FeesStructureDetail fee, CancellationToken cancellationToken);

    Task DeleteAsync(FeesStructureDetail fee, CancellationToken cancellationToken);

}