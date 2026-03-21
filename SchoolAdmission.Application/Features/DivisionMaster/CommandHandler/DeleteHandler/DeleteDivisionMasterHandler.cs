using MediatR;
using SchoolAdmission.Infrastructure.Interfaces;
//using SchoolAdmission.Domain;

namespace SchoolAdmission.Application.Features.DivisionMasters.Commands;

public class DeleteDivisionMasterCommandHandler(IDivisionMasterRepository repository)
        : IRequestHandler<DeleteDivisionMasterCommand, bool>
{
    public async Task<bool> Handle(DeleteDivisionMasterCommand request, CancellationToken cancellationToken)
    {
        // Get entity
        var entity = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (entity == null)
            return false;

        // Delete entity
        await repository.Delete(entity, cancellationToken);

        return true;
    }
}