using MediatR;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.CasteMasters.Commands;

public class DeleteCasteMasterHandler(ICasteMasterRepository repository)
    : IRequestHandler<DeleteCasteMasterCommand, bool>
{
    public async Task<bool> Handle(DeleteCasteMasterCommand request,CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (entity is null)
            return false;

        await repository.DeleteAsync(entity,cancellationToken);
        return true;
    }
}