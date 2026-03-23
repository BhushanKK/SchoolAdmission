using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.Utils;

public class SaveStudentDocumentHandler(IStudentDocumentRepository repo)
    : IRequestHandler<SaveStudentDocumentCommand, ApiResponse<int>>
{
    public async Task<ApiResponse<int>> Handle(SaveStudentDocumentCommand request, CancellationToken cancellationToken)
    {
        var dto = new StudentDocumentDto
        {
            DocumentId = request.DocumentId,
            StudentId = request.StudentId,
            DocumentType = request.DocumentType,
            DocumentPath = request.DocumentPath,
            UploadedDate = request.UploadedDate
        };

        int result = await repo.SaveStudentDocumentAsync(dto, cancellationToken);
        if(result>0)
        {
            return new ApiResponse<int>
            {
                Success = true,
                Data = result,
                Message = MessageHelper.CreatedSuccessfully(EntityEnum.StudentDocument)
            };
        }
        else
        {
            return new ApiResponse<int>
            {
                Success = false,
                Message = MessageHelper.InternalServerError(EntityEnum.StudentDocument)
            };
        }
    }
}
