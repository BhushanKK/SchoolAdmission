using MediatR;
using SchoolAdmission.Domain;

namespace SchoolAdmission.Application.Features.CasteMasters.Queries;

public class GetAllCasteMastersHandler(ICasteMasterRepository repository)
    : IRequestHandler<GetAllCasteMastersQuery, List<CasteMaster>>
{
    public async Task<List<CasteMaster>> Handle(GetAllCasteMastersQuery request, CancellationToken cancellationToken)
    {
        var data = await repository.GetAllAsync(cancellationToken);

        return data.Select(x => new CasteMaster
        {
            CasteId = x.CasteId,
            CategoryId = x.CategoryId,
            Caste = x.Caste
        }).ToList();
    }
}