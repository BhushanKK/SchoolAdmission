using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.ResponseModels;

public record GetStudentByIdQuery(Guid Id) : IRequest<ApiResponse<StudentDetailsQueryDto?>>;