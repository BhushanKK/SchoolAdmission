using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.BranchMasters.Queries;

public class GetBranchMasterByIdHandler(IBranchMasterRepository repository)
    : IRequestHandler<GetBranchMasterByIdQuery, BranchMasterQueryDto?>
{
    public async Task<BranchMasterQueryDto?> Handle(
        GetBranchMasterByIdQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id,cancellationToken);

        if (entity == null)
            return null;

        return new BranchMasterQueryDto
        {
            BranchId= entity.BranchId,
            BranchName = entity.BranchName
        };
    }
}
          