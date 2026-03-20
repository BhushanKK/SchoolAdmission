using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.FeesStructureDetails.Commands;

public class CreateFeesStructureDetailCommand :  FeesStructureDetailCommandDto,IRequest<int>;