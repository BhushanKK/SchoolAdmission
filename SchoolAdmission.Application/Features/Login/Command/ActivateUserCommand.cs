using MediatR;
using SchoolAdmission.Domain.Utils;

namespace SchoolAdmission.Application.Features.UserLogin.Commands.ActivateUser;

public class ActivateUserCommand : IRequest<ApiResponse<string>>
{
    public Guid StudentId { get; set; }
}