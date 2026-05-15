using MediatR;
using SchoolAdmission.Domain.ResponseModels;
using SchoolAdmission.Domain.ViewModels;
namespace SchoolAdmission.Application.Features.StudentDetails.Queries;

public record GetStudentReportQuery(Guid StudentId)
    : IRequest<ApiResponse<StudentDetailsView>>;
