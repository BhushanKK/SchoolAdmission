using MediatR;

namespace SchoolAdmission.Application.Features.Religions.Commands;

public record DeleteReligionMasterCommand(int Id) : IRequest<bool>;