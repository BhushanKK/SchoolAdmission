using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.FeesStructureDetails.Queries;

public class GetFeesStructureByIdHandler(IFeesStructureDetailsRepository repository)
    : IRequestHandler<GetFeesStructureByIdQuery, FeesStructureQueryDto?>
{
    public async Task<FeesStructureQueryDto?> Handle(
        GetFeesStructureByIdQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id,cancellationToken);

        if (entity == null)
            return null;

        return new FeesStructureQueryDto
        {
            FeeId = entity.FeeId,
            FeeHeadDescription = entity.FeeHeadDescription,
            StandardId = entity.StandardId,
            Amount = entity.Amount,
            BranchId = entity.BranchId
        };
    }
}