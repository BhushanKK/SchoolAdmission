using MediatR;
using AutoMapper;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.CategoryMasters.Commands;

public class UpdateCategoryMasterHandler(ICategoryMasterRepository repository,IMapper mapper)
    : IRequestHandler<UpdateCategoryMasterCommand, bool>
{
    public async Task<bool> Handle(UpdateCategoryMasterCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.CategoryId, cancellationToken);

        if (entity == null)
            return false;
    
        entity.categoryId = request.CategoryId;

        mapper.Map(request, entity);

        await repository.UpdateAsync(entity, cancellationToken);

        return true;
    }
}