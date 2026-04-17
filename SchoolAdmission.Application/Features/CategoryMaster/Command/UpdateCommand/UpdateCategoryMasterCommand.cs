using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.CategoryMasters.Commands;

public class UpdateCategoryMasterCommand : CategoryMasterCommandDto, IRequest<ApiResponse<bool>>;
