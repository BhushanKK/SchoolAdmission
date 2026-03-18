namespace SchoolAdmission.Infrastructure.Interfaces;

public interface IJwtRepository
{
    Task<string> GenerateToken(UsersLogin user);
    Task<string> GenerateRefreshToken();
}