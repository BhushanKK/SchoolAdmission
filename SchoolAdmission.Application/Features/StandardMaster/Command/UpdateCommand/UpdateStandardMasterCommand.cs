using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.StandardMasters.Commands;

public class UpdateStandardMasterCommand : StandardMasterCommandDto, IRequest<ApiResponse<bool>>;
