using MediatR;

namespace SchoolAdmission.Application.Features.CategoryMasters.Commands;

public record DeleteCategoryMasterCommand(int Id) : IRequest<ApiResponse<bool>>;
