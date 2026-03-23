
namespace SchoolAdmission.Infrastructure.Interfaces;
public interface IUserLoginRepository
{
    Task AddAsync(UsersLogin user,CancellationToken cancellationToken);
}
