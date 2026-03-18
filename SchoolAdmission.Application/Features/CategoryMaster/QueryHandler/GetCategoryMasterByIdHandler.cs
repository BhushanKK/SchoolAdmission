using MediatR;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.CategoryMasters.Queries;

public class GetCategoryMasterByIdHandler(ICategoryMasterRepository repository)
    : IRequestHandler<GetCategoryMasterByIdQuery, CategoryMaster?>
{
    public async Task<CategoryMaster?> Handle(GetCategoryMasterByIdQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id,cancellationToken);

        if (entity == null)
            return null;

        return new CategoryMaster
        {
            categoryId = entity.categoryId,
            Category = entity.Category
        };
    }
}
          