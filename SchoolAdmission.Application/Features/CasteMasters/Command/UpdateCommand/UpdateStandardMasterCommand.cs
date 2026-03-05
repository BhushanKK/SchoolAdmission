using MediatR;

namespace SchoolAdmission.Application.Features.StandardMasters.Commands;

public record UpdateStandardMasterCommand(
    int Id,
    string? StandardName
) : IRequest<bool>;