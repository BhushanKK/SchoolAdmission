using MediatR;
using Microsoft.Extensions.Logging;
using System.Net;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Application.Features.UserLogin.Commands.ActivateUser;

namespace SchoolAdmission.Application.Features.UsersLogin.Commands.ActivateUser;

public class ActivateUserHandler(
    IUserLoginRepository repository,
    ILogger<ActivateUserHandler> logger,
    ApplicationDbContext context
) : IRequestHandler<ActivateUserCommand, ApiResponse<string>>
{
    public async Task<ApiResponse<string>> Handle(ActivateUserCommand request, CancellationToken cancellationToken)
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

            if (user.IsActive && !user.IsLocked && user.FailedLoginAttempts == 0)
            {
                return ApiResponse<string>.SuccessResponse(null,
                    "User already active",
                    HttpStatusCode.OK.GetHashCode()
                );
            }
            user.IsActive = true;
            user.IsLocked = false;
            user.FailedLoginAttempts = 0;

            await repository.UpdateAsync(user, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            await transaction.CommitAsync(cancellationToken);

            return ApiResponse<string>.SuccessResponse(null,
                "Student activated successfully",
                HttpStatusCode.OK.GetHashCode()
            );
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);

            logger.LogError(ex, "Error while activating student with StudentId: {StudentId}", request.StudentId);

            return ApiResponse<string>.FailureResponse(
                MessageHelper.InternalServerError(EntityEnum.UserLogin),
                HttpStatusCode.InternalServerError.GetHashCode()
            );
        }
    }
}