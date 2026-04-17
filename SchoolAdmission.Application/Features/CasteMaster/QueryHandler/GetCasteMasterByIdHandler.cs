using System.Net;
using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.ResponseModels;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.CasteMasters.Queries;

public class GetCasteMasterByIdHandler(ICasteMasterRepository repository)
    : IRequestHandler<GetCasteMasterByIdQuery, ApiResponse<CasteMasterQueryDto?>>
{
    public async Task<ApiResponse<CasteMasterQueryDto?>> Handle(
        GetCasteMasterByIdQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id,cancellationToken);

        if (entity == null)
            return new ApiResponse<CasteMasterQueryDto?>
            {
                Success = false,
                Message = MessageHelper.NotFound(EntityEnum.CasteMaster, request.Id),
                StatusCode = HttpStatusCode.NotFound.GetHashCode(),
                Data = null
            };

        return new ApiResponse<CasteMasterQueryDto?>
        {
            Success = true,
            Message = MessageHelper.RetrievedSuccessfully(EntityEnum.CasteMaster),
            StatusCode = HttpStatusCode.OK.GetHashCode(),
            Data = new CasteMasterQueryDto
            {
                CasteId= entity.CasteId,
                CategoryId = entity.CategoryId,
                Caste= entity.Caste
            }
        };
    }
}
          
