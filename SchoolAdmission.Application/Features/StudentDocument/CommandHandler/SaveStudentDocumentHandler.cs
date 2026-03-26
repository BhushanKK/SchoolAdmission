using MediatR;
using SchoolAdmission.Domain.Utils;

public class SaveStudentDocumentHandler(IStudentDocumentRepository repo)
    : IRequestHandler<SaveStudentDocumentCommand, ApiResponse<int>>
{
    public async Task<ApiResponse<int>> Handle(SaveStudentDocumentCommand request, CancellationToken cancellationToken)
    {
        int result = await repo.SaveStudentDocumentAsync(request, cancellationToken);
        if (result > 0)
        {
            return ApiResponse<int>.SuccessResponse
            (
                result,
                MessageHelper.CreatedSuccessfully(EntityEnum.StudentDocument),
                System.Net.HttpStatusCode.Created.GetHashCode()
            );
        }
        return ApiResponse<int>.FailureResponse(MessageHelper.InternalServerError(EntityEnum.StudentDocument), System.Net.HttpStatusCode.InternalServerError.GetHashCode());
    }
}
