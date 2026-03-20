using MediatR;

namespace SchoolAdmission.Application.Features.FeesStructureDetails.Commands;

public record DeleteFeesStructureDetailCommand(int Id) : IRequest<bool>;