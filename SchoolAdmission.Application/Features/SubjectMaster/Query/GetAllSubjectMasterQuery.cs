using MediatR;
using SchoolAdmission.Domain.Entities;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.SubjectMasters.Queries;

public record GetAllSubjectMasterQuery()
    : IRequest<ApiResponse<List<SubjectMaster>>>;
