using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.ReligionMasters.Commands;

public class CreateReligionMasterCommand :  ReligionMasterCommandDto,IRequest<ApiResponse<int>>;