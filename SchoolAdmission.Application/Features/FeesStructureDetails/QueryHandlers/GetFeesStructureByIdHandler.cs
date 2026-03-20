using MediatR;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.FeesStructureDetails.Queries;

public class GetFeesStructureByIdHandler(IFeesStructureDetailRepository repository)
    : IRequestHandler<GetFeesStructureByIdQuery, FeesStructureDetail?>
{
    public async Task<FeesStructureDetail?> Handle(
        GetFeesStructureByIdQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id,cancellationToken);

        if (entity == null)
            return null;

        return new FeesStructureDetail
        {
            FeeId = entity.FeeId,
            FeeHeadDescription = entity.FeeHeadDescription,
            StandardId = entity.StandardId,
            Amount = entity.Amount,
            BranchId = entity.BranchId
        };
    }
}