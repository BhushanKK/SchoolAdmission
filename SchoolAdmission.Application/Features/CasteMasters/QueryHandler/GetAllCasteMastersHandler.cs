using MediatR;
using SchoolAdmission.Application.Common.Interfaces;
using SchoolAdmission.Application.Dtos;

namespace SchoolAdmission.Application.Features.CasteMasters.Queries;

public class GetAllCasteMastersHandler(ICasteMasterRepository repository)
    : IRequestHandler<GetAllCasteMastersQuery, List<CasteMasterDto>>
{
    public async Task<List<CasteMasterDto>> Handle(GetAllCasteMastersQuery request, CancellationToken cancellationToken)
    {
        var data = await repository.GetAllAsync();

        return data.Select(x => new CasteMasterDto
        {
            CasteId = x.CasteId,
            CategoryId = x.CategoryId,
            Caste = x.Caste
        }).ToList();
    }
}