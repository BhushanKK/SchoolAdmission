using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.CategoryMasters.Queries;

public record GetCategoryMasterByIdQuery(int Id)
    : IRequest<ApiResponse<CategoryMasterQueryDto?>>;
