using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.StudentParents.Queries;

public record GetStudentParentsByStudentIdQuery(Guid StudentId)
    : IRequest<ApiResponse<StudentParentsQueryDto?>>;