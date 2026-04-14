using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.SubjectMasters.Queries;

public record GetSubjectMasterByIdQuery(int SubjectId)
    : IRequest<ApiResponse<SubjectMasterQueryDto?>>;
