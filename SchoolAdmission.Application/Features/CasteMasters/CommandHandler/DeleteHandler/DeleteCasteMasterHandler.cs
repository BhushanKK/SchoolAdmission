using MediatR;
using SchoolAdmission.Application.Common.Interfaces;

namespace SchoolAdmission.Application.Features.CasteMasters.Commands;

public class DeleteCasteMasterHandler
    : IRequestHandler<DeleteCasteMasterCommand, bool>
{
    private readonly ICasteMasterRepository _repository;

    public DeleteCasteMasterHandler(ICasteMasterRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        DeleteCasteMasterCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id);

        if (entity == null)
            return false;

        await _repository.DeleteAsync(entity);
        await _repository.SaveChangesAsync();

        return true;
    }
}