using MediatR;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.Religions.Commands;

public class DeleteReligionMasterHandler(
    IReligionMasterRepository repository
) : IRequestHandler<DeleteReligionMasterCommand, bool>
{
    public async Task<bool> Handle(DeleteReligionMasterCommand request, CancellationToken cancellationToken)
    {
        // Get the entity by Id
        var entity = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (entity is null)
            return false;

        // Delete using repository
        await repository.DeleteAsync(entity.ReligionId, cancellationToken);

        return true;
    }
}