using System.Net;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SchoolAdmission.Application.Features.Login.Commands;
using SchoolAdmission.Domain.Dtos.CommandDto;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.Login.Handlers;

public class TokenHandler(
    ApplicationDbContext context,
    IJwtRepository jwtService,
    IConfiguration config)
    : IRequestHandler<LoginCommand, ApiResponse<LoginResponseDto>>
{
    public async Task<ApiResponse<LoginResponseDto>> Handle(
        LoginCommand request,
        CancellationToken cancellationToken)
    {
        var user = await context.UsersLogins
            .FirstOrDefaultAsync(x => x.EmailId == request.EmailId, cancellationToken);

        if (user is null)
            return ApiResponse<LoginResponseDto>.FailureResponse("Invalid email or password.", HttpStatusCode.Unauthorized.GetHashCode());

        if (!user.IsActive)
            return ApiResponse<LoginResponseDto>.FailureResponse("User inactive.", HttpStatusCode.Unauthorized.GetHashCode());

        if (user.IsLocked)
            return ApiResponse<LoginResponseDto>.FailureResponse("User account locked.", HttpStatusCode.Unauthorized.GetHashCode());

        var validPassword = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);

        if (!validPassword)
        {
            user.FailedLoginAttempts++;

            if (user.FailedLoginAttempts >= 5)
                user.IsLocked = true;

            await context.SaveChangesAsync(cancellationToken);

            throw new UnauthorizedAccessException("Invalid email or password");
        }

        user.FailedLoginAttempts = 0;
        user.LastLoginDate = DateTime.UtcNow;

        var accessToken = await jwtService.GenerateToken(user);
        var refreshToken = await jwtService.GenerateRefreshToken();

        double accessMinutes = Convert.ToDouble(config["Jwt:AccessTokenMinutes"] ?? "60");

        user.AccessToken = accessToken;
        user.RefreshToken = refreshToken;
        user.AccessTokenExpiry = DateTime.UtcNow.AddMinutes(accessMinutes);
        user.LastLoginDate = DateTime.UtcNow;
        user.RoleId = user.RoleId;

        await context.SaveChangesAsync(cancellationToken);

        return ApiResponse<LoginResponseDto>.SuccessResponse
        (
            new LoginResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                AccessTokenExpiry = user.AccessTokenExpiry.Value,
                UserId = user.UserId,
                EmailId = user.EmailId,
                Role = user.RoleId == 1 ? "Admin" : "Student"
            },
            "Login successful.",
            HttpStatusCode.OK.GetHashCode()
        );
    }
}
