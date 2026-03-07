using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.Religions.Commands;

public class UpdateReligionMasterCommand : ReligionMasterCommandDto,IRequest<bool>;