using MediatR;
using SchoolAdmission.Domain;

namespace SchoolAdmission.Application.Features.BranchMasters.Queries;

public record GetAllBranchMasterQuery()
    : IRequest<ApiResponse<List<BranchMaster>>>;