using MediatR;
using SchoolAdmission.Application.Dtos;
using SchoolAdmission.Domain;

namespace SchoolAdmission.Application.Features.CategoryMasters.Queries;

public record GetAllCategoryMastersQuery()
    : IRequest<List<CategoryMaster>>;