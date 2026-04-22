using System.Net;
using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.StudentSubjectChoice.Queries;

public class GetStudentSubjectChoiceByStudentIdHandler(
    IStudentSubjectChoiceRepository repository)
    : IRequestHandler<GetStudentSubjectChoiceByStudentIdQuery,
        ApiResponse<List<StudentSubjectChoiceQueryDto>>>
{
    public async Task<ApiResponse<List<StudentSubjectChoiceQueryDto>>> Handle(
        GetStudentSubjectChoiceByStudentIdQuery request,
        CancellationToken cancellationToken)
    {
        var entities = await repository.GetByStudentIdAsync(
            request.StudentId,
            cancellationToken);

        if (entities == null || !entities.Any())
        {
            return ApiResponse<List<StudentSubjectChoiceQueryDto>>.FailureResponse(
                MessageHelper.NotFound(EntityEnum.StudentSubjectChoice, request.StudentId),
                HttpStatusCode.NotFound.GetHashCode());
        }

        var result = entities.Select(x => new StudentSubjectChoiceQueryDto
        {
            ChoiceId = x.ChoiceId ?? 0,
            StudentId = x.StudentId,
            BranchId = x.BranchId,
            SubjectId = x.SubjectId,
            GroupId = x.GroupId
        }).ToList();

        return ApiResponse<List<StudentSubjectChoiceQueryDto>>.SuccessResponse(
            result,
            MessageHelper.RetrievedSuccessfully(EntityEnum.StudentSubjectChoice),
            HttpStatusCode.OK.GetHashCode());
    }
}