using MediatR;
using SchoolAdmission.Application.Common.Interfaces;

namespace SchoolAdmission.Application.Features.CasteMasters.Commands;

public class UpdateCasteMasterHandler
    : IRequestHandler<UpdateCasteMasterCommand, bool>
{
    private readonly ICasteMasterRepository _repository;

    public UpdateCasteMasterHandler(ICasteMasterRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        UpdateCasteMasterCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.CasteId);

        if (entity == null)
            return false;

        entity.CategoryId = request.CategoryId;
        entity.Caste = request.Caste;

        await _repository.UpdateAsync(entity);
        await _repository.SaveChangesAsync();

        return true;
    }
}