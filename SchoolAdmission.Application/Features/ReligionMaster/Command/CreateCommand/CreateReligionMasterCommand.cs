using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.Religions.Commands;

public class CreateReligionMasterCommand :  ReligionMasterCommandDto,IRequest<int>;