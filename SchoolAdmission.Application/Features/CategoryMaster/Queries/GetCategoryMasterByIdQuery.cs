using MediatR;
using SchoolAdmission.Application.Dtos;

namespace SchoolAdmission.Application.Features.CategoryMasters.Queries;

public record GetCategoryMasterByIdQuery(int Id)
    : IRequest<CategoryMasterDto?>;