using MediatR;
using SchoolAdmission.Domain;

namespace SchoolAdmission.Application.Features.StandardMasters.Queries;

public record GetAllStandardMasterQuery()
    : IRequest<ApiResponse<List<StandardMaster>>>;
