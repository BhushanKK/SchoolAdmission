using MediatR;
using SchoolAdmission.Domain;

namespace SchoolAdmission.Application.Features.SchoolMasters.Queries;

public record GetAllSchoolMasterQuery()
    : IRequest<ApiResponse<List<SchoolMaster>>>;