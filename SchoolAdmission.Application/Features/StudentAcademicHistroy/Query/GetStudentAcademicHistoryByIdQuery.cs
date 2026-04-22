using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.StudentAcademicHistory.Queries;

public record GetStudentAcademicHistoryByStudentIdQuery(Guid StudentId)
    : IRequest<ApiResponse<StudentAcademicHistoryQueryDto?>>;