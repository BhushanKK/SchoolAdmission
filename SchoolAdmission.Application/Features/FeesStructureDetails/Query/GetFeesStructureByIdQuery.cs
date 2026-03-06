using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.FeesStructureDetails.Queries;

public record GetFeesStructureByIdQuery(int Id)
    : IRequest<FeesStructureQueryDto?>;