using MediatR;
using SchoolAdmission.Domain;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.BranchMasters.Queries;

public record GetAllBranchMasterQuery()
    : IRequest<ApiResponse<List<BranchMaster>>>;
