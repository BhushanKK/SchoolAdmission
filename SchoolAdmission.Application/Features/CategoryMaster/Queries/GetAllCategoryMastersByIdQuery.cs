using MediatR;
using SchoolAdmission.Application.Dtos;

namespace SchoolAdmission.Application.Features.CategoryMaster.Queries;

public record GetAllCategoryMastersByIdQuery(int Id)
    : IRequest<CategoryMasterDto?>;