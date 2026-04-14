using MediatR;
using SchoolAdmission.Domain.Entities;

namespace SchoolAdmission.Application.Features.SubjectMasters.Queries;

public record GetAllSubjectMasterQuery()
    : IRequest<ApiResponse<List<SubjectMaster>>>;
