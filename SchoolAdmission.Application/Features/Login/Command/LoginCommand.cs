using MediatR;
using SchoolAdmission.Domain.Dtos.CommandDto;

namespace SchoolAdmission.Application.Features.Login.Commands;
public record LoginCommand(string EmailId, string Password)
    : IRequest<LoginResponseDto>;