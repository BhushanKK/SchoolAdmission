using System.Net;
using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.ReligionMasters.Queries;

public class GetReligionMasterByIdHandler(
        IReligionMasterRepository repository
    ) : IRequestHandler<GetReligionMasterByIdQuery, ApiResponse<ReligionMasterQueryDto?>>
{
    public async Task<ApiResponse<ReligionMasterQueryDto?>> Handle(
        GetReligionMasterByIdQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (entity == null)
            return ApiResponse<ReligionMasterQueryDto?>.FailureResponse("ReligionMaster not found", 404);

        var result = new ReligionMasterQueryDto
        {
            ReligionId = entity.ReligionId,
            Religion = entity.Religion
        };

        return ApiResponse<ReligionMasterQueryDto?>.SuccessResponse(
            result,
            MessageHelper.RetrievedSuccessfully(EntityEnum.ReligionMaster),
            HttpStatusCode.OK.GetHashCode()
        );
    }
}
