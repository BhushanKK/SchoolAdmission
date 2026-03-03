using MediatR;
using SchoolAdmission.Application.Common.Interfaces;

namespace SchoolAdmission.Application.Features.CasteMasters.Commands;

public class UpdateCasteMasterHandler(ICasteMasterRepository repository)
    : IRequestHandler<UpdateCasteMasterCommand, bool>
{
    public async Task<bool> Handle(UpdateCasteMasterCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.CasteId);

        if (entity == null)
            return false;

        entity.CategoryId = request.CategoryId;
        entity.Caste = request.Caste;

        await repository.UpdateAsync(entity);
        await repository.SaveChangesAsync();

        return true;
    }
}