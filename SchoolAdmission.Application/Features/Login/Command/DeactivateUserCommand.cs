using MediatR;

namespace SchoolAdmission.Application.Features.UsersLogin.Commands.DeactivateUser;

public class DeactivateUserCommand : IRequest<ApiResponse<string>>
{
    public Guid StudentId { get; set; }
}