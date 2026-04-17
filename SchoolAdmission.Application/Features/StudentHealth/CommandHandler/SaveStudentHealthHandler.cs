using MediatR;
using SchoolAdmission.Infrastructure.Interfaces;
using SchoolAdmission.Domain.Utils;

namespace SchoolAdmission.Application.Features.StudentHealth.Commands;
public class SaveStudentHealthHandler(IStudentHealthRepository repo)
    : IRequestHandler<SaveStudentHealthCommand, ApiResponse<int>>
{
    public async Task<ApiResponse<int>> Handle(SaveStudentHealthCommand request, CancellationToken cancellationToken)
    {
        int result = await repo.SaveStudentHealthAsync(request, cancellationToken);
        if (result > 0)
        {
            return ApiResponse<int>.SuccessResponse
            (
                result,
                MessageHelper.CreatedSuccessfully(EntityEnum.StudentHealth),
                System.Net.HttpStatusCode.Created.GetHashCode()
            );
        }
        return ApiResponse<int>.FailureResponse(MessageHelper.InternalServerError(EntityEnum.StudentHealth), System.Net.HttpStatusCode.InternalServerError.GetHashCode());
    }
}
