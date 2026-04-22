using System.Net;
using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.StudentDocument.Queries;

public class GetStudentDocumentByStudentIdHandler(IStudentDocumentRepository repository)
    : IRequestHandler<GetStudentDocumentByStudentIdQuery, ApiResponse<List<StudentDocumentQueryDto?>>>
{
    public async Task<ApiResponse<List<StudentDocumentQueryDto?>>> Handle(
        GetStudentDocumentByStudentIdQuery request,
        CancellationToken cancellationToken)
    {
        var entities = await repository.GetByStudentIdAsync(request.StudentId, cancellationToken);

        if (entities == null || !entities.Any())
            return ApiResponse<List<StudentDocumentQueryDto?>>.FailureResponse(
                MessageHelper.NotFound(EntityEnum.StudentDocument, request.StudentId),
                HttpStatusCode.NotFound.GetHashCode());

        var result = entities.Select(entity => new StudentDocumentQueryDto
        {
            DocumentId = entity.DocumentId,
            StudentId = entity.StudentId,
            DocumentType = entity.DocumentType,
            DocumentPath = entity.DocumentPath,
            UploadedDate = entity.UploadedDate
        }).ToList();

        return ApiResponse<List<StudentDocumentQueryDto?>>.SuccessResponse(
            result,
            MessageHelper.RetrievedSuccessfully(EntityEnum.StudentDocument),
            HttpStatusCode.OK.GetHashCode());
    }
}