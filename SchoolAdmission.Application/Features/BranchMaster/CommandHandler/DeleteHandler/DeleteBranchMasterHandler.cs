using MediatR;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.BranchMasters.Commands;

public class DeleteBranchMasterCommandHandler(IBranchMasterRepository repository)
    : IRequestHandler<DeleteBranchMasterCommand, bool>
{
    public async Task<bool> Handle(DeleteBranchMasterCommand request,CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (entity is null)
            return false;

        await repository.Delete(entity,cancellationToken);
        return true;
    }
}