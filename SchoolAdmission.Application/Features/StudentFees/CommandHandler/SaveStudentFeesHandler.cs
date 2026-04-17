using MediatR;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.StudentFees.Commands;
public class SaveStudentFeesHandler(IStudentFeesRepository repo)
    : IRequestHandler<SaveStudentFeesCommand, ApiResponse<int>>
{
    public async Task<ApiResponse<int>> Handle(SaveStudentFeesCommand request, CancellationToken cancellationToken)
    {
        int result = await repo.SaveStudentFeesAsync(request, cancellationToken);
        if (result > 0)
        {
            return ApiResponse<int>.SuccessResponse
            (
                result,
                MessageHelper.CreatedSuccessfully(EntityEnum.StudentFees),
                System.Net.HttpStatusCode.Created.GetHashCode()
            );
        }
        return ApiResponse<int>.FailureResponse(MessageHelper.InternalServerError(EntityEnum.StudentFees), System.Net.HttpStatusCode.InternalServerError.GetHashCode());
    }
}
