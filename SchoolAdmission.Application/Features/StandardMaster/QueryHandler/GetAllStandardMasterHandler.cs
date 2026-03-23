using System.Net;
using MediatR;
using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.StandardMasters.Queries;

public class GetAllStandardMasterHandler(
        IStandardMasterRepository repository
    ) : IRequestHandler<GetAllStandardMasterQuery, ApiResponse<List<StandardMaster>>>
{
    public async Task<ApiResponse<List<StandardMaster>>> Handle(GetAllStandardMasterQuery request, CancellationToken cancellationToken)
    {
        var data = await repository.GetAllAsync(cancellationToken);

        return ApiResponse<List<StandardMaster>>.SuccessResponse(
            data.Select(x => new StandardMaster
            {
                StandardId = x.StandardId,
                StandardName = x.StandardName
            }).ToList(),
            MessageHelper.RetrievedSuccessfully(EntityEnum.StandardMaster),
            HttpStatusCode.OK.GetHashCode()
        );
    }
}