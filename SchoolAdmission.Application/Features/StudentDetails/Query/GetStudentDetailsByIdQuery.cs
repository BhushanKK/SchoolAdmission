using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.StudentDetails.Queries;

public record GetStudentDetailsByIdQuery(int Id)
    : IRequest<ApiResponse<StudentDetailsQueryDto?>>;
