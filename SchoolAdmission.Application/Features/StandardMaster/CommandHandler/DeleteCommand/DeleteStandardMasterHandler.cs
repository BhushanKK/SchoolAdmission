using MediatR;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.StandardMasters.Commands;

public class DeleteStandardMasterHandler(
    IStandardMasterRepository repository
) : IRequestHandler<DeleteStandardMasterCommand, bool>
{
    public async Task<bool> Handle(DeleteStandardMasterCommand request, CancellationToken cancellationToken)
    {
        // Get the entity by Id
        var entity = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (entity is null)
            return false;

        // Delete using repository
        await repository.DeleteAsync(entity.StandardId, cancellationToken);

        return true;
    }
}