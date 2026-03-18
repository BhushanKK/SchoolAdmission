using MediatR;
using SchoolAdmission.Domain;

namespace SchoolAdmission.Application.Features.CategoryMasters.Queries;

public record GetCategoryMasterByIdQuery(int Id)
    : IRequest<CategoryMaster?>;