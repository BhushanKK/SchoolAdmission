using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Domain.Entities;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Infrastructure.Repositories;
public class UserLoginRepository(ApplicationDbContext context) : IUserLoginRepository
{
    public async Task AddAsync(UsersLogin user, CancellationToken cancellationToken)
    {
        await context.UsersLogins.AddAsync(user, cancellationToken);
    }

    public async Task<UsersLogin?> GetByStudentIdAsync(Guid studentId, CancellationToken cancellationToken)
    {
        return await context.UsersLogins
            .FirstOrDefaultAsync(x => x.StudentId.HasValue && x.StudentId.Value == studentId, cancellationToken);
    }

    public Task UpdateAsync(UsersLogin user, CancellationToken cancellationToken)
    {
        context.UsersLogins.Update(user);
        return Task.CompletedTask;
    }
}