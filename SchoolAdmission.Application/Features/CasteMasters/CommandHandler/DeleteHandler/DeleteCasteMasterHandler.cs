using MediatR;
using SchoolAdmission.Application.Common.Interfaces;

namespace SchoolAdmission.Application.Features.CasteMasters.Commands;

public class DeleteCasteMasterHandler(ICasteMasterRepository repository)
    : IRequestHandler<DeleteCasteMasterCommand, bool>
{
    public async Task<bool> Handle(
        DeleteCasteMasterCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id);

        if (entity == null)
            return false;

        await repository.DeleteAsync(entity);
        await repository.SaveChangesAsync();

        return true;
    }
}