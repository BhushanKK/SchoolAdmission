using System.Net;
using MediatR;
using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.CasteMasters.Queries;

public class GetAllCasteMasterHandler(ICasteMasterRepository repository)
    : IRequestHandler<GetAllCasteMasterQuery, ApiResponse<List<CasteMaster>>>
{
    public async Task<ApiResponse<List<CasteMaster>>> Handle(GetAllCasteMasterQuery request, CancellationToken cancellationToken)
    {
        var data = await repository.GetAllAsync(cancellationToken);

        return ApiResponse<List<CasteMaster>>.SuccessResponse
        (
            data.Select(x => new CasteMaster
            {
                CasteId = x.CasteId,
                CategoryId = x.CategoryId,
                Caste = x.Caste
            }).ToList(),

            MessageHelper.RetrievedSuccessfully(EntityEnum.CasteMaster),
            HttpStatusCode.OK.GetHashCode()
        );
    }
}