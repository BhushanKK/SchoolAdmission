using MediatR;
using SchoolAdmission.Domain;

namespace SchoolAdmission.Application.Features.CategoryMasters.Queries;

public class GetAllCategoryMastersHandler(ICategoryMasterRepository repository)
    : IRequestHandler<GetAllCategoryMastersQuery, List<CategoryMaster>>
{
    public async Task<List<CategoryMaster>> Handle(GetAllCategoryMastersQuery request, CancellationToken cancellationToken)
    {
        var data = await repository.GetAllAsync(cancellationToken);

        return data.Select(x => new CategoryMaster
        {
            categoryId = x.categoryId,
            Category = x.Category
        }).ToList();
    }
}