using System.Net;
using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.ResponseModels;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.StudentSubjectChoice.Queries;

public class GetStudentStandardByStudentIdHandler(
    IStudentSubjectChoiceRepository repository)
    : IRequestHandler<
        GetStudentStandardByStudentIdQuery,
        ApiResponse<StudentSubjectChoiceQueryDto>>
{
    public async Task<ApiResponse<StudentSubjectChoiceQueryDto>> Handle(
        GetStudentStandardByStudentIdQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(
            request.StudentId,
            cancellationToken);

        if (entity == null)
        {
            return ApiResponse<StudentSubjectChoiceQueryDto>.FailureResponse(
                MessageHelper.NotFound(
                    EntityEnum.StudentSubjectChoice,
                    request.StudentId),
                HttpStatusCode.NotFound.GetHashCode());
        }

        var result = new StudentSubjectChoiceQueryDto
        {
            StudentId = entity.StudentId,
            StandardId = entity.StandardId,
            BranchId = entity.BranchId
        };

        return ApiResponse<StudentSubjectChoiceQueryDto>.SuccessResponse(
            result,
            MessageHelper.RetrievedSuccessfully(
                EntityEnum.StudentSubjectChoice),
            HttpStatusCode.OK.GetHashCode());
    }
}