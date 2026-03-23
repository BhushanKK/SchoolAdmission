using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.FeesStructureDetails.Queries;

public record GetAllFeesStructureDetailsQuery()
    : IRequest<List<FeesStructureQueryDto>>;
