using MediatR;

namespace SchoolAdmission.Application.Features.StudentDetails.Queries;

public record GetAllStudentDetailsQuery()
    : IRequest<ApiResponse<List<StudentDetailsView>>>;
