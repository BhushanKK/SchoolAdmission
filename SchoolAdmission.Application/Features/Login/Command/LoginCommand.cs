using MediatR;
using SchoolAdmission.Domain.Dtos.CommandDto;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.Login.Commands;
public record LoginCommand(string EmailOrMobile, string Password)
    : IRequest<ApiResponse<LoginResponseDto>>;
