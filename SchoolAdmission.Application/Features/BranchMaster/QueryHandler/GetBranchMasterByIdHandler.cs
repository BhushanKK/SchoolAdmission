using MediatR;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.BranchMasters.Queries;

public class GetBranchMasterByIdHandler(IBranchMasterRepository repository)
    : IRequestHandler<GetBranchMasterByIdQuery, BranchMaster?>
{
    public async Task<BranchMaster?> Handle(
        GetBranchMasterByIdQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (entity == null)
            return null;

        return new BranchMaster
        {
            BranchId = entity.BranchId,
            BranchName = entity.BranchName
        };
    }
}