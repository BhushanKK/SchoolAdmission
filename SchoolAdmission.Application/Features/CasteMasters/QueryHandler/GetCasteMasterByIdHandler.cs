using MediatR;
using SchoolAdmission.Application.Common.Interfaces;
using SchoolAdmission.Application.Dtos;

namespace SchoolAdmission.Application.Features.CasteMasters.Queries;

public class GetCasteMasterByIdHandler(ICasteMasterRepository repository)
    : IRequestHandler<GetCasteMasterByIdQuery, CasteMasterDto?>
{
    public async Task<CasteMasterDto?> Handle(
        GetCasteMasterByIdQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id);

        if (entity == null)
            return null;

        return new CasteMasterDto
        {
            CasteId = entity.CasteId,
            CategoryId = entity.CategoryId,
            Caste = entity.Caste
        };
    }
}