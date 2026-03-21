using MediatR;
using AutoMapper;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.CasteMasters.Commands;

public class UpdateCasteMasterHandler(ICasteMasterRepository repository, IMapper mapper)
    : IRequestHandler<UpdateCasteMasterCommand, ApiResponse<int>>
{
    public async Task<ApiResponse<int>> Handle(UpdateCasteMasterCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.CasteId, cancellationToken);

        if (entity == null)
        {
            return new ApiResponse<int>
            {
                Success = false,
                Message = $"CasteMaster with Id {request.CasteId} not found",
                StatusCode = 404
            };
        }

        entity.CasteId = request.CasteId;

        mapper.Map(request, entity);

        await repository.Update(entity, cancellationToken);

        return ApiResponse<int>.SuccessResponse(entity.CasteId, "CasteMaster updated successfully", 200);
    }
}