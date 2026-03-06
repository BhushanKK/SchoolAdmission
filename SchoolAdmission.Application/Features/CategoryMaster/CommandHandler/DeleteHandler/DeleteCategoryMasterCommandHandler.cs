using MediatR;

namespace SchoolAdmission.Application.Features.CategoryMasters.Commands;

public class DeleteCategoryMasterCommandHandler(ICategoryMasterRepository repository)
    : IRequestHandler<DeleteCategoryMasterCommand, bool>
{
    public async Task<bool> Handle(DeleteCategoryMasterCommand request,CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (entity is null)
            return false;

        await repository.Delete(entity,cancellationToken);
        return true;
    }
}