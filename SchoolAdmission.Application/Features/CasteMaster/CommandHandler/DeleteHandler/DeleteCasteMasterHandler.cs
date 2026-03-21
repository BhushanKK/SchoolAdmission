using MediatR;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.CasteMasters.Commands;

public class DeleteCasteMasterCommandHandler(ICasteMasterRepository repository)
    : IRequestHandler<DeleteCasteMasterCommand, ApiResponse<bool>>
{
    public async Task<ApiResponse<bool>> Handle(DeleteCasteMasterCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (entity == null)
        {
            return new ApiResponse<bool>
            {
                Success = false,
                Message = $"CasteMaster with Id {request.Id} not found",
                StatusCode = 404
            };
        }

        await repository.Delete(entity, cancellationToken);
        return ApiResponse<bool>.SuccessResponse(true, "CasteMaster deleted successfully", 200);
    }
}