using MediatR;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.FeesStructureDetails.Commands;

public class DeleteFeesStructureHandler(
    IFeesStructureDetailRepository repository
) : IRequestHandler<DeleteFeesStructureDetailCommand, bool>
{
    public async Task<bool> Handle(DeleteFeesStructureDetailCommand request, CancellationToken cancellationToken)
    {
        // Get the entity by Id
        var entity = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (entity is null)
            return false;

        // Delete using repository
        await repository.DeleteAsync(entity, cancellationToken);

        return true;
    }
}