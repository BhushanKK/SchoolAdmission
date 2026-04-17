using MediatR;
using SchoolAdmission.Domain;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.SchoolMasters.Queries;

public record GetAllSchoolMasterQuery(int? CommiteeId)
    : IRequest<ApiResponse<List<SchoolMaster>>>;
