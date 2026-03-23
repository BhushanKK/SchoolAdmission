using System.Net;
using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.StandardMasters.Queries;

public class GetStandardMasterByIdHandler(
        IStandardMasterRepository repository
    ) : IRequestHandler<GetStandardMasterByIdQuery, ApiResponse<StandardMasterQueryDto?>>
{
    public async Task<ApiResponse<StandardMasterQueryDto?>> Handle(
        GetStandardMasterByIdQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (entity == null)
            return ApiResponse<StandardMasterQueryDto?>.FailureResponse("StandardMaster not found", 404);

        return ApiResponse<StandardMasterQueryDto?>.SuccessResponse(
            new StandardMasterQueryDto
            {
                StandardId = entity.StandardId,
                StandardName = entity.StandardName
            },
            MessageHelper.RetrievedSuccessfully(EntityEnum.StandardMaster),
            HttpStatusCode.OK.GetHashCode()
        );
    }
}
