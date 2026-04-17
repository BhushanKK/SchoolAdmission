using MediatR;
using SchoolAdmission.Domain.ResponseModels;
using SchoolAdmission.Domain.ViewModels;
namespace SchoolAdmission.Application.Features.StudentDetails.Queries;

public record GetAllStudentDetailsQuery()
    : IRequest<ApiResponse<List<StudentDetailsView>>>;
