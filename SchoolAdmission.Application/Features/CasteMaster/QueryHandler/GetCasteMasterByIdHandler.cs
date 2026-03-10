using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.CasteMasters.Queries;

public class GetCasteMasterByIdHandler(ICasteMasterRepository repository)
    : IRequestHandler<GetCasteMasterByIdQuery, CasteMasterQueryDto?>
{
    public async Task<CasteMasterQueryDto?> Handle(
        GetCasteMasterByIdQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id,cancellationToken);

        if (entity == null)
            return null;

        return new CasteMasterQueryDto
        {
            CasteId= entity.CasteId,
            CategoryId = entity.CategoryId
        };
    }
}
          