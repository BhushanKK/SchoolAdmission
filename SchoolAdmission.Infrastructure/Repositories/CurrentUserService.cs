using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using SchoolAdmission.Infrastructure.Interfaces;

public class CurrentUserRepository(IHttpContextAccessor httpContextAccessor) : ICurrentUserRepository
{
    public Task<string?> Email =>
        Task.FromResult(httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value);

    public Task<string?> UserId
    {
        get
        {
            var value = httpContextAccessor.HttpContext?.User?.FindFirst("UserId")?.Value;
            return Task.FromResult(value);
        }
    }
}
