using MediatR;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.DivisionMasters.Commands;

public class DeleteDivisionMasterCommandHandler(IDivisionMasterRepository repository)
    : IRequestHandler<DeleteDivisionMasterCommand, bool>
{
    public async Task<bool> Handle(DeleteDivisionMasterCommand request,CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (entity is null)
            return false;

        await repository.DeleteAsync(entity,cancellationToken);
        return true;
    }
}