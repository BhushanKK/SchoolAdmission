using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.StudentHealth.Queries;

public record GetStudentHealthByStudentIdQuery(Guid StudentId)
    : IRequest<ApiResponse<StudentHealthQueryDto?>>;