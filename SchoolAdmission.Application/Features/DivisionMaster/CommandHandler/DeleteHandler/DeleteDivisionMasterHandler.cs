using MediatR;
//using SchoolAdmission.Domain;

namespace SchoolAdmission.Application.Features.DivisionMasters.Commands;

public class DeleteDivisionMasterCommandHandler 
    : IRequestHandler<DeleteDivisionMasterCommand, bool>
{
    private readonly IDivisionMasterRepository _repository;

    public DeleteDivisionMasterCommandHandler(IDivisionMasterRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteDivisionMasterCommand request, CancellationToken cancellationToken)
    {
        // Get entity
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (entity == null)
            return false;

        // Delete entity
        await _repository.Delete(entity, cancellationToken);

        return true;
    }
}