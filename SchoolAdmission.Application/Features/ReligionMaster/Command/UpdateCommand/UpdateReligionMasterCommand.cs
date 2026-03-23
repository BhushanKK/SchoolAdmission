using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.ReligionMasters.Commands;

public class UpdateReligionMasterCommand : ReligionMasterCommandDto,IRequest<ApiResponse<bool>>;
