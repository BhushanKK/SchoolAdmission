using MediatR;

namespace SchoolAdmission.Application.Features.CasteMasters.Commands;

public record DeleteCasteMasterCommand(int Id) : IRequest<bool>;