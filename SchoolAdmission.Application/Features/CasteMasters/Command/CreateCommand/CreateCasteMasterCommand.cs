using MediatR;

namespace SchoolAdmission.Application.Features.CasteMasters.Commands;

public record CreateCasteMasterCommand(
    int? CategoryId,
    string? Caste
) : IRequest<int>;