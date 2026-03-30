using MediatR;
using SchoolAdmission.Domain.Utils;

namespace SchoolAdmission.Application.Features.UsersLogin.Commands.StudentActiveDeactive;

public class StudentActiveDeactiveCommand : IRequest<ApiResponse<string>>
{
    public Guid StudentId { get; set; }
    public bool Status { get; set; } 
}