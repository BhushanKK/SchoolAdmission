using MediatR;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.CommiteMasters.Commands;

public class DeleteCommiteMasterCommandHandler(
    ICommiteMasterRepository repository
) : IRequestHandler<DeleteCommiteMasterCommand, bool>
{
    public async Task<bool> Handle(DeleteCommiteMasterCommand request,CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (entity is null)
            return false;

        await repository.DeleteAsync(entity,cancellationToken);
        return true;
    }
}