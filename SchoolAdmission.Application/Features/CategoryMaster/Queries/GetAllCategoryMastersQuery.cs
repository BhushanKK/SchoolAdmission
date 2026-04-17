using MediatR;
using SchoolAdmission.Domain;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.CategoryMasters.Queries;

public record GetAllCategoryMastersQuery()
    : IRequest<ApiResponse<List<CategoryMaster>>>;
