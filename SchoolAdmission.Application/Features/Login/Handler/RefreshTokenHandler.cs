using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SchoolAdmission.Application.Features.Login.Commands;
using SchoolAdmission.Domain.Dtos.CommandDto;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.Login.Handlers;
public class RefreshTokenHandler(
    ApplicationDbContext context,
    IJwtRepository jwtService,
    IConfiguration config)
    : IRequestHandler<RefreshTokenCommand, LoginResponseDto>
{
    public async Task<LoginResponseDto> Handle(
        RefreshTokenCommand request,
        CancellationToken cancellationToken)
    {
        var user = await context.UsersLogins
            .FirstOrDefaultAsync(x =>
                x.RefreshToken == request.RefreshToken,
                cancellationToken);

        if (user is null)
            throw new UnauthorizedAccessException("Invalid refresh token");

        if (user.RefreshTokenExpiry < DateTime.UtcNow)
            throw new UnauthorizedAccessException("Refresh token expired");

        var newAccessToken = await jwtService.GenerateToken(user);

        double accessMinutes =
            Convert.ToDouble(config["Jwt:AccessTokenMinutes"] ?? "60");

        user.AccessToken = newAccessToken;
        user.AccessTokenExpiry = DateTime.UtcNow.AddMinutes(accessMinutes);

        await context.SaveChangesAsync(cancellationToken);

        return new LoginResponseDto
        {
            AccessToken = newAccessToken,
            RefreshToken = user.RefreshToken!,
            AccessTokenExpiry = user.AccessTokenExpiry!.Value
        };
    }
}