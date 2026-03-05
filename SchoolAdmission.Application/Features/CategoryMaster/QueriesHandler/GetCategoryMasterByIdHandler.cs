using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.CategoryMasters.Queries;

public class GetCategoryMasterByIdHandler(ICategoryMasterRepository repository)
    : IRequestHandler<GetCategoryMasterByIdQuery, CategoryMasterQueryDto?>
{
    public async Task<CategoryMasterQueryDto?> Handle(
        GetCategoryMasterByIdQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id,cancellationToken);

        if (entity == null)
            return null;

        return new CategoryMasterQueryDto
        {
            CategoryId= entity.categoryId,
            CategoryName = entity.Category
        };
    }
}
          