using MediatR;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.FeesStructureDetails.Queries;

public class GetAllFeesStructureHandler(IFeesStructureDetailRepository repository)
: IRequestHandler<GetAllFeesStructureDetailsQuery, List<FeesStructureDetail>>
{
    public async Task<List<FeesStructureDetail>> Handle(GetAllFeesStructureDetailsQuery request, CancellationToken cancellationToken)
    {
        var data = await repository.GetAllAsync(cancellationToken);

        return data.Select(x => new FeesStructureDetail
        {
            FeeId = x.FeeId,
            FeeHeadDescription = x.FeeHeadDescription,
            StandardId = x.StandardId,
            Amount = x.Amount,
            BranchId = x.BranchId
        }).ToList();
    }
}