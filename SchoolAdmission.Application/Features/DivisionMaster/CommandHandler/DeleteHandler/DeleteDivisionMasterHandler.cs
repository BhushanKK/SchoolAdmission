using MediatR;

namespace SchoolAdmission.Application.Features.DivisionMasters.Commands;

public class DeleteDivisionMasterCommandHandler(
    IDivisionMasterRepository repository
) : IRequestHandler<DeleteDivisionMasterCommand, bool>
{
    public async Task<bool> Handle(DeleteDivisionMasterCommand request, CancellationToken cancellationToken)
    {
        // Get the entity by Id
        var entity = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (entity is null)
            return false;

        // Delete using repository
        await repository.Delete(entity, cancellationToken);

        return true;
    }
}