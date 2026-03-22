using System.Net;
using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.DivisionMasters.Queries;

public class GetDivisionMasterByIdHandler(
    IDivisionMasterRepository repository
) : IRequestHandler<GetDivisionMasterByIdQuery, ApiResponse<DivisionMasterQueryDto?>>
{
    public async Task<ApiResponse<DivisionMasterQueryDto?>> Handle(
        GetDivisionMasterByIdQuery request,
        CancellationToken cancellationToken)
    {
        // Fetch entity by ID
        var entity = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (entity == null)
            return ApiResponse<DivisionMasterQueryDto?>.FailureResponse(
                "DivisionMaster not found", 
                404
            );

        // Map entity to DTO
        var dto = new DivisionMasterQueryDto
        {
            DivisionId = entity.DivisionId,
            DivisionName = entity.DivisionName
        };

        return ApiResponse<DivisionMasterQueryDto?>.SuccessResponse(
            dto,
            MessageHelper.RetrievedSuccessfully(EntityEnum.DivisionMaster),
            HttpStatusCode.OK.GetHashCode()
        );
    }
}