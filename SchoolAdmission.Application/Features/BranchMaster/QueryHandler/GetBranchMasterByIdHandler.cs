using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.BranchMasters.Queries;

public class GetBranchMasterByIdHandler(IBranchMasterRepository repository)
    : IRequestHandler<GetBranchMasterByIdQuery, ApiResponse<BranchMasterQueryDto?>>
{
    public async Task<ApiResponse<BranchMasterQueryDto?>> Handle(
        GetBranchMasterByIdQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id,cancellationToken);

        if (entity == null)
            return ApiResponse<BranchMasterQueryDto?>.FailureResponse("BranchMaster not found", 404);

        return ApiResponse<BranchMasterQueryDto?>.SuccessResponse(new BranchMasterQueryDto
        {
            BranchId= entity.BranchId,
            BranchName = entity.BranchName
        }, "Data retrieved successfully", 200);
    }
}
          