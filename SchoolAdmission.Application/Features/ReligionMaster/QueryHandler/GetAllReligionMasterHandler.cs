using MediatR;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.Religions.Queries;

public class GetAllReligionMastersHandler(IReligionMasterRepository repository)
    : IRequestHandler<GetAllReligionMastersQuery, List<ReligionMaster>>
{
    public async Task<List<ReligionMaster>> Handle(GetAllReligionMastersQuery request, CancellationToken cancellationToken)
    {
        var data = await repository.GetAllAsync(cancellationToken);

        return data.Select(x => new ReligionMaster
        {
            ReligionId = x.ReligionId,
            Religion = x.Religion
        }).ToList();
    }
}