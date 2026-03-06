using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.FeesStructureDetails.Commands;

public class CreateFeesStructureCommand :  FeesStructureCommandDto,IRequest<int>;