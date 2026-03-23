using MediatR;
using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.CategoryMasters.Queries;

public class GetAllCategoryMastersHandler(ICategoryMasterRepository repository)
    : IRequestHandler<GetAllCategoryMastersQuery, ApiResponse<List<CategoryMaster>>>
{
    public async Task<ApiResponse<List<CategoryMaster>>> Handle(GetAllCategoryMastersQuery request, CancellationToken cancellationToken)
    {
        var data = await repository.GetAllAsync(cancellationToken);

        return ApiResponse<List<CategoryMaster>>.SuccessResponse(
            data.Select(x => new CategoryMaster
            {
                categoryId = x.categoryId,
                Category = x.Category
            }).ToList(),
            MessageHelper.RetrievedSuccessfully(EntityEnum.CategoryMaster),
            System.Net.HttpStatusCode.OK.GetHashCode()
        );
    }
}
