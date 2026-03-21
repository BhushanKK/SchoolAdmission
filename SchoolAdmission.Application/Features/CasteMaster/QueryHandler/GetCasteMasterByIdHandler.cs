using MediatR;
using SchoolAdmission.Domain.Dtos;
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
                Message = $"CasteMaster with Id {request.Id} not found",
                StatusCode = 404
            };

        return new ApiResponse<CasteMasterQueryDto?>
        {
            Success = true,
            Message = "CasteMaster retrieved successfully",
            StatusCode = 200,
            Data = new CasteMasterQueryDto
            {
                CasteId= entity.CasteId,
                CategoryId = entity.CategoryId,
                Caste= entity.Caste
            }
        };
    }
}
          