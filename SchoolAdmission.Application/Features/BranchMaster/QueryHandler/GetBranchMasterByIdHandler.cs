using System.Net;
using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.Utils;
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

        if (entity is null)
            return ApiResponse<BranchMasterQueryDto?>.FailureResponse(MessageHelper.NotFound(EntityEnum.BranchMaster,request.Id), HttpStatusCode.NotFound.GetHashCode());

        return ApiResponse<BranchMasterQueryDto?>.SuccessResponse(new BranchMasterQueryDto
        {
            BranchId= entity.BranchId,
            BranchName = entity.BranchName
        }, MessageHelper.RetrievedSuccessfully(EntityEnum.BranchMaster), HttpStatusCode.OK.GetHashCode());
    }
}
          
