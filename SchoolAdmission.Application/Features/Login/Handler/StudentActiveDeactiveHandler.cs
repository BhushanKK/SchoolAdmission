using MediatR;
using Microsoft.Extensions.Logging;
using System.Net;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;
using SchoolAdmission.Infrastructure.Data;

namespace SchoolAdmission.Application.Features.UsersLogin.Commands.StudentActiveDeactive;

public class StudentActiveDeactiveHandler(
    IUserLoginRepository repository,
    ILogger<StudentActiveDeactiveHandler> logger,
    ApplicationDbContext context
) : IRequestHandler<StudentActiveDeactiveCommand, ApiResponse<string>>
{
    public async Task<ApiResponse<string>> Handle(StudentActiveDeactiveCommand request, CancellationToken cancellationToken)
    {
        await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var user = await repository.GetByStudentIdAsync(request.StudentId, cancellationToken);

            if (user == null)
            {
                return ApiResponse<string>.FailureResponse(
                    "User not found",
                    HttpStatusCode.NotFound.GetHashCode()
                );
            }

            if (request.Status)
            {
                if (user.IsActive && !user.IsLocked && user.FailedLoginAttempts == 0)
                {
                    return ApiResponse<string>.SuccessResponse(
                        null,
                        "User already active",
                        HttpStatusCode.OK.GetHashCode()
                    );
                }

                user.IsActive = true;
                user.IsLocked = false;
                user.FailedLoginAttempts = 0;
            }
            else
            {
                user.IsActive = false;
                user.IsLocked = true;
                user.FailedLoginAttempts = 0;
            }

            await repository.UpdateAsync(user, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            await transaction.CommitAsync(cancellationToken);

            var message = request.Status
                ? "Student activated successfully"
                : "Student deactivated successfully";

            return ApiResponse<string>.SuccessResponse(
                null,
                message,
                HttpStatusCode.OK.GetHashCode()
            );
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);

            logger.LogError(ex, "Error while changing user status for StudentId: {StudentId}", request.StudentId);

            return ApiResponse<string>.FailureResponse(
                MessageHelper.InternalServerError(EntityEnum.UserLogin),
                HttpStatusCode.InternalServerError.GetHashCode()
            );
        }
    }
}