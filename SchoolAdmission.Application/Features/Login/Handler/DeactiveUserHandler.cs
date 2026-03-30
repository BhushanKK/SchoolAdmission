using MediatR;
using SchoolAdmission.Application.Features.UsersLogin.Commands.DeactivateUser;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;

public class DeactivateUserHandler(
    IUserLoginRepository repository,
    ApplicationDbContext context
) : IRequestHandler<DeactivateUserCommand, ApiResponse<string>>
{
    public async Task<ApiResponse<string>> Handle(DeactivateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await repository.GetByStudentIdAsync(request.StudentId, cancellationToken);

        if (user == null)
        {
            return ApiResponse<string>.FailureResponse("User not found", 404);
        }

        user.IsActive = false;
        user.IsLocked = true;
        user.FailedLoginAttempts = 0;

        await repository.UpdateAsync(user, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return ApiResponse<string>.SuccessResponse(null, "User deactivated successfully", 200);
    }
}