using MediatR;

namespace SchoolAdmission.Application.Features.FeesStructureDetails.Commands;

public record DeleteFeesStructureCommand(int Id) : IRequest<bool>;