using System.Net;
using MediatR;
using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.ReligionMasters.Queries;

public class GetAllReligionMastersHandler(IReligionMasterRepository repository)
    : IRequestHandler<GetAllReligionMastersQuery, ApiResponse<List<ReligionMasterQueryDto>>>
{
    public async Task<ApiResponse<List<ReligionMasterQueryDto>>> Handle(GetAllReligionMastersQuery request, 
    CancellationToken cancellationToken)
    {
        var data = await repository.GetAllAsync(cancellationToken);

        return ApiResponse<List<ReligionMasterQueryDto>>.SuccessResponse(data.Select(x => new ReligionMasterQueryDto
        {
            ReligionId = x.ReligionId,
            Religion = x.Religion
        }).ToList(), 
        MessageHelper.RetrievedSuccessfully(EntityEnum.ReligionMaster), 
        HttpStatusCode.OK.GetHashCode());
    }
}