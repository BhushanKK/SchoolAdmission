using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.FeesStructureDetails.Queries;

public class GetAllFeesStructureDetailsHandler(IFeesStructureDetailsRepository repository)
    : IRequestHandler<GetAllFeesStructureDetailsQuery, List<FeesStructureQueryDto>>
{
    public async Task<List<FeesStructureQueryDto>> Handle(GetAllFeesStructureDetailsQuery request, CancellationToken cancellationToken)
    {
        var data = await repository.GetAllAsync(cancellationToken);

        return data.Select(x => new FeesStructureQueryDto
        {
            FeeId = x.FeeId,
            FeeHeadDescription = x.FeeHeadDescription,
            StandardId = x.StandardId,
            Amount = x.Amount,
            BranchId = x.BranchId
        }).ToList();
    }
}