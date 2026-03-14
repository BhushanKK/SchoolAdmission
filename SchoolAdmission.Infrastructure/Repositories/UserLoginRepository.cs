using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;

public class UserLoginRepository(ApplicationDbContext context) : IUserLoginRepository
{
    public async Task AddAsync(UsersLogin user,CancellationToken cancellationToken)
    {
        await context.UsersLogins.AddAsync(user);
    }
}