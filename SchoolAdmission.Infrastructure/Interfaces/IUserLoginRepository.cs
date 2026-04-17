
using SchoolAdmission.Domain.Entities;

namespace SchoolAdmission.Infrastructure.Interfaces;
public interface IUserLoginRepository
{
    Task AddAsync(UsersLogin user,CancellationToken cancellationToken);
    Task<UsersLogin?> GetByStudentIdAsync(Guid studentId, CancellationToken cancellationToken);
    Task UpdateAsync(UsersLogin user, CancellationToken cancellationToken);
}
