using MediatR;

namespace SchoolAdmission.Application.Features.DivisionMasters.Commands;

public record DeleteDivisionMasterCommand(int Id) : IRequest<bool>;
