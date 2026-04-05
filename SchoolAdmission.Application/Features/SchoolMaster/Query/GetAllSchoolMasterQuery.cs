using MediatR;
using SchoolAdmission.Domain;

namespace SchoolAdmission.Application.Features.SchoolMasters.Queries;

public record GetAllSchoolMasterQuery(int? CommiteeId)
    : IRequest<ApiResponse<List<SchoolMaster>>>;
