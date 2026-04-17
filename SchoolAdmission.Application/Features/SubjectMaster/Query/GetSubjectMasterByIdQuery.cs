using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.SubjectMasters.Queries;

public record GetSubjectMasterByIdQuery(int SubjectId)
    : IRequest<ApiResponse<SubjectMasterQueryDto?>>;
