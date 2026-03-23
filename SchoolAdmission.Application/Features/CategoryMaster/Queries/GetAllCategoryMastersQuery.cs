using MediatR;
using SchoolAdmission.Domain;

namespace SchoolAdmission.Application.Features.CategoryMasters.Queries;

public record GetAllCategoryMastersQuery()
    : IRequest<ApiResponse<List<CategoryMaster>>>;
