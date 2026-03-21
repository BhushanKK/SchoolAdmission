using MediatR;
using AutoMapper;
using SchoolAdmission.Infrastructure.Interfaces;
using System.Net;

namespace SchoolAdmission.Application.Features.CasteMasters.Commands;

public class UpdateCasteMasterHandler(ICasteMasterRepository repository, IMapper mapper)
    : IRequestHandler<UpdateCasteMasterCommand, ApiResponse<int>>
{
    public async Task<ApiResponse<int>> Handle(UpdateCasteMasterCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.CasteId, cancellationToken);

        if (entity is null)
        {
            return new ApiResponse<int>
            {
                Success = false,
                Message = $"CasteMaster with Id {request.CasteId} not found",
                StatusCode = HttpStatusCode.NotFound.GetHashCode()
            };
        }

        entity.CasteId = request.CasteId;

        mapper.Map(request, entity);

        await repository.UpdateAsync(entity, cancellationToken);

        return ApiResponse<int>.SuccessResponse(entity.CasteId, "CasteMaster updated successfully", 200);
    }
}