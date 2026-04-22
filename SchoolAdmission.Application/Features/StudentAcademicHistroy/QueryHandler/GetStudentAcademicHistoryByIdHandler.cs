using System.Net;
using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.StudentAcademicHistory.Queries;

public class GetStudentAcademicHistoryByStudentIdHandler(
    IStudentAcademicHistoryRepository repository)
    : IRequestHandler<GetStudentAcademicHistoryByStudentIdQuery, ApiResponse<StudentAcademicHistoryQueryDto?>>
{
    public async Task<ApiResponse<StudentAcademicHistoryQueryDto?>> Handle(
        GetStudentAcademicHistoryByStudentIdQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await repository.GetByStudentIdAsync(request.StudentId, cancellationToken);

        if (entity is null)
            return ApiResponse<StudentAcademicHistoryQueryDto?>.FailureResponse(
                MessageHelper.NotFound(EntityEnum.StudentAcademicHistory, request.StudentId),
                HttpStatusCode.NotFound.GetHashCode());

        return ApiResponse<StudentAcademicHistoryQueryDto?>.SuccessResponse(
            new StudentAcademicHistoryQueryDto
            {
                AcademicHistoryId = entity.AcademicHistoryId,
                StudentId = entity.StudentId,
                PreviousSchool = entity.PreviousSchool,
                SchoolDOE = entity.SchoolDOE,
                Progress = entity.Progress,
                Behaviour = entity.Behaviour,
                PassingYear = entity.PassingYear,
                SeatNo = entity.SeatNo,
                TotalMarks = entity.TotalMarks,
                Percentage = entity.Percentage
            },
            MessageHelper.RetrievedSuccessfully(EntityEnum.StudentAcademicHistory),
            HttpStatusCode.OK.GetHashCode());
    }
}