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
            return new ApiResponse<int>
            {
                Success = true,
                Data = result,
                Message = MessageHelper.CreatedSuccessfully(EntityEnum.StudentDocument)
            };
        }

        return new ApiResponse<int>
        {
            Success = false,
            Message = MessageHelper.InternalServerError(EntityEnum.StudentDocument)
        };
    }
}
