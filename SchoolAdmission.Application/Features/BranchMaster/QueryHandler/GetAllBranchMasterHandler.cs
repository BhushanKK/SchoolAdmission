using MediatR;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.BranchMasters.Queries;

public class GetAllBranchMasterHandler(IBranchMasterRepository repository)
    : IRequestHandler<GetAllBranchMasterQuery, ApiResponse<List<BranchMaster>>>
{
    public async Task<ApiResponse<List<BranchMaster>>> Handle(GetAllBranchMasterQuery request, CancellationToken cancellationToken)
    {
        var data = await repository.GetAllAsync(cancellationToken);

        return ApiResponse<List<BranchMaster>>.SuccessResponse(data.Select(x => new BranchMaster
        {
            BranchId = x.BranchId,
            BranchName = x.BranchName
        }).ToList(), "Data retrieved successfully", 200);
    }
}