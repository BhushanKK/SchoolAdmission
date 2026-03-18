using MediatR;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.StandardMasters.Queries;

public class GetAllStandardMastersHandler(IStandardMasterRepository repository)
    : IRequestHandler<GetAllStandardMastersQuery, List<StandardMaster>>
{
    public async Task<List<StandardMaster>> Handle(GetAllStandardMastersQuery request, CancellationToken cancellationToken)
    {
        var data = await repository.GetAllAsync(cancellationToken);

        return data.Select(x => new StandardMaster
        {
            StandardId = x.StandardId,
            StandardName = x.StandardName
        }).ToList();
    }
}