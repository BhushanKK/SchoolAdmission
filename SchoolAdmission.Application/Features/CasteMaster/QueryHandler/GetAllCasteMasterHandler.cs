using System.Net;
using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.CasteMasters.Queries;

public class GetAllCasteMasterHandler(ICasteMasterRepository repository)
    : IRequestHandler<GetAllCasteMasterQuery, ApiResponse<List<CasteMasterQueryDto>>>
{
    public async Task<ApiResponse<List<CasteMasterQueryDto>>> Handle(GetAllCasteMasterQuery request, CancellationToken cancellationToken)
    {
        var data = await repository.GetAllAsync(cancellationToken);

        return ApiResponse<List<CasteMasterQueryDto>>.SuccessResponse
        (
            data.Select(x => new CasteMasterQueryDto
            {
                CasteId = x.CasteId,
                CategoryId = x.CategoryId,
                Caste = x.Caste,
                Category = x.Category
            }).ToList(),

            MessageHelper.RetrievedSuccessfully(EntityEnum.CasteMaster),
            HttpStatusCode.OK.GetHashCode()
        );
    }
}
