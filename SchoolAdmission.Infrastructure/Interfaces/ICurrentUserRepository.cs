namespace SchoolAdmission.Infrastructure.Interfaces;
public interface ICurrentUserRepository
{
    Task<string?> Email { get; }
    Task<string?> UserId { get; }
}
