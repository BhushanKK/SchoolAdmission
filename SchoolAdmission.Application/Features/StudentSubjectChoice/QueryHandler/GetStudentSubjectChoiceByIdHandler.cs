using System.Net;
using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.StudentSubjectChoice.Queries;

public class GetStudentSubjectChoiceByIdHandler(
    IStudentSubjectChoiceRepository repository)
    : IRequestHandler<GetStudentSubjectChoiceByIdQuery, ApiResponse<StudentSubjectChoiceQueryDto?>>
{
    public async Task<ApiResponse<StudentSubjectChoiceQueryDto?>> Handle(
        GetStudentSubjectChoiceByIdQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (entity is null)
            return ApiResponse<StudentSubjectChoiceQueryDto?>.FailureResponse(
                MessageHelper.NotFound(EntityEnum.StudentSubjectChoice, request.Id),
                HttpStatusCode.NotFound.GetHashCode()
            );

        return ApiResponse<StudentSubjectChoiceQueryDto?>.SuccessResponse(
            new StudentSubjectChoiceQueryDto
            {
                ChoiceId = (int)entity.ChoiceId,
                StudentId = entity.StudentId,
                SubjectId = entity.SubjectId
            },
            MessageHelper.RetrievedSuccessfully(EntityEnum.StudentSubjectChoice),
            HttpStatusCode.OK.GetHashCode()
        );
    }
}