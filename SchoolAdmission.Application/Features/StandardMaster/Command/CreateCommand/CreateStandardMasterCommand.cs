using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.StandardMasters.Commands;

public class CreateStandardMasterCommand : StandardMasterCommandDto, IRequest<ApiResponse<int>>;