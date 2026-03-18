using MediatR;
using SchoolAdmission.Domain.Dtos.CommandDto;

namespace SchoolAdmission.Application.Features.Login.Commands;
public record RefreshTokenCommand(
    string AccessToken,
    string RefreshToken) : IRequest<LoginResponseDto>;