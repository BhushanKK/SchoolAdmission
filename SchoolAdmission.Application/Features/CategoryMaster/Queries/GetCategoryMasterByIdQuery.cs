using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.CategoryMasters.Queries;

public record GetCategoryMasterByIdQuery(int Id)
    : IRequest<ApiResponse<CategoryMasterQueryDto?>>;