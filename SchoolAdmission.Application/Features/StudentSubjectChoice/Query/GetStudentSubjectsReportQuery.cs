using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.StudentSubjectChoice.Queries;

public record GetStudentSubjectsReportQuery(Guid StudentId)
    : IRequest<ApiResponse<List<StudentSubjectReport>>>;