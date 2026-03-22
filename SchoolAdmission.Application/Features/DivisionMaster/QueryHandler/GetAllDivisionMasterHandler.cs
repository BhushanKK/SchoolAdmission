using System.Net;
using MediatR;
using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.DivisionMasters.Queries;

public class GetAllDivisionMasterHandler(
    IDivisionMasterRepository repository
) : IRequestHandler<GetAllDivisionMastersQuery, ApiResponse<List<DivisionMaster>>>
{
    public async Task<ApiResponse<List<DivisionMaster>>> Handle(
        GetAllDivisionMastersQuery request, 
        CancellationToken cancellationToken)
    {
        // Fetch all divisions
        var data = await repository.GetAllAsync(cancellationToken);

        // Map to list
        var result = data.Select(x => new DivisionMaster
        {
            DivisionId = x.DivisionId,
            DivisionName = x.DivisionName
        }).ToList();

        return ApiResponse<List<DivisionMaster>>.SuccessResponse(
            result,
            MessageHelper.RetrievedSuccessfully(EntityEnum.DivisionMaster),
            HttpStatusCode.OK.GetHashCode()
        );
    }
}