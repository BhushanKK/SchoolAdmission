using MediatR;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.CasteMasters.Commands;

public class DeleteCasteMasterCommandHandler(ICasteMasterRepository repository)
    : IRequestHandler<DeleteCasteMasterCommand, bool>
{
    public async Task<bool> Handle(DeleteCasteMasterCommand request,CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (entity is null)
            return false;

        await repository.Delete(entity,cancellationToken);
        return true;
    }
}