using MediatR;

namespace SchoolAdmission.Application.Features.CasteMasters.Commands;

public record UpdateCasteMasterCommand(
    int CasteId,
    int? CategoryId,
    string? Caste
) : IRequest<bool>;