using MediatR;
using SchoolAdmission.Domain.Dtos;

public record GetStudentByIdQuery(Guid Id) : IRequest<ApiResponse<StudentDetailsQueryDto?>>;