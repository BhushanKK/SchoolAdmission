using System.Net;
using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.StudentSubjectChoice.Queries;

public class GetStudentSubjectsReportHandler(
    IStudentSubjectReportRepository repository)
    : IRequestHandler<GetStudentSubjectsReportQuery,
        ApiResponse<List<StudentSubjectReport>>>
{
    public async Task<ApiResponse<List<StudentSubjectReport>>> Handle(
        GetStudentSubjectsReportQuery request,
        CancellationToken cancellationToken)
    {
        var entities = await repository.GetAllStudentSubjectsAsync(
            request.StudentId,
            cancellationToken);

        if (entities == null || !entities.Any())
        {
            return ApiResponse<List<StudentSubjectReport>>.FailureResponse(
                MessageHelper.NotFound(EntityEnum.StudentSubjectChoice, request.StudentId),
                HttpStatusCode.NotFound.GetHashCode());
        }

        var result = entities.Select(x => new StudentSubjectReport
        {
            BranchName = x.BranchName,
            GroupName = x.GroupName,
            SubjectName = x.SubjectName,
        }).ToList();

        return ApiResponse<List<StudentSubjectReport>>.SuccessResponse(
            result,
            MessageHelper.RetrievedSuccessfully(EntityEnum.StudentSubjectChoice),
            HttpStatusCode.OK.GetHashCode());
    }
}