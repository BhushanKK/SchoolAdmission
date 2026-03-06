using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.FeesStructureDetails.Commands;

public class UpdateFeesStructureCommand : FeesStructureCommandDto,IRequest<bool>;