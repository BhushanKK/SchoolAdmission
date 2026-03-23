using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.CategoryMasters.Commands;

public class UpdateCategoryMasterCommand : CategoryMasterCommandDto, IRequest<ApiResponse<bool>>;
