using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.CategoryMasters.Queries;

public class GetCategoryMasterByIdHandler(ICategoryMasterRepository repository)
    : IRequestHandler<GetCategoryMasterByIdQuery, ApiResponse<CategoryMasterQueryDto?>>
{
    public async Task<ApiResponse<CategoryMasterQueryDto?>> Handle(
        GetCategoryMasterByIdQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (entity == null)
            return ApiResponse<CategoryMasterQueryDto?>.FailureResponse
            (
                MessageHelper.NotFound(EntityEnum.CategoryMaster, request.Id),
                System.Net.HttpStatusCode.NotFound.GetHashCode()
            );

        return ApiResponse<CategoryMasterQueryDto?>.SuccessResponse
        (
            new CategoryMasterQueryDto
            {
                CategoryId = entity.categoryId,
                CategoryName = entity.Category
            },
            MessageHelper.RetrievedSuccessfully(EntityEnum.CategoryMaster),
            System.Net.HttpStatusCode.OK.GetHashCode()
        );
    }
}

