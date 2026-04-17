using MediatR;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Domain.ResponseModels;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.StudentAcademicHistory.Commands;

public class SaveStudentAcademicHistoryHandler(IStudentAcademicHistoryRepository repo) 
    : IRequestHandler<SaveStudentAcademicHistoryCommand, ApiResponse<int>>
{
    public async Task<ApiResponse<int>> Handle(SaveStudentAcademicHistoryCommand request, CancellationToken cancellationToken)
    {
        int result = await repo.SaveStudentAcademicHistoryAsync(request, cancellationToken);
        if(result>0)
        {
            return ApiResponse<int>.SuccessResponse
            (
                result, 
                MessageHelper.CreatedSuccessfully(EntityEnum.StudentAcademicHistory), 
                System.Net.HttpStatusCode.Created.GetHashCode()
            );
        }
        return ApiResponse<int>.FailureResponse(MessageHelper.InternalServerError(EntityEnum.StudentAcademicHistory), System.Net.HttpStatusCode.InternalServerError.GetHashCode());
    }
}
