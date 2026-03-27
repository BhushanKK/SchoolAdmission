using MediatR;
using SchoolAdmission.Infrastructure.Interfaces;
using SchoolAdmission.Domain.Utils;

public class SaveStudentParentHandler(IStudentParentsRepository repo)
    : IRequestHandler<SaveStudentParentCommand, ApiResponse<int>>
{
    public async Task<ApiResponse<int>> Handle(SaveStudentParentCommand request, CancellationToken cancellationToken)
    {
        int result = await repo.SaveStudentParentsAsync(request, cancellationToken);
        if(result>0)
        {
            return ApiResponse<int>.SuccessResponse
            (
                result, 
                MessageHelper.CreatedSuccessfully(EntityEnum.StudentParents), 
                System.Net.HttpStatusCode.Created.GetHashCode()
            );
        }
        return ApiResponse<int>.FailureResponse(MessageHelper.InternalServerError(EntityEnum.StudentParents), System.Net.HttpStatusCode.InternalServerError.GetHashCode());  
    }
}
