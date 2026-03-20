using MediatR;
using SchoolAdmission.Domain;

namespace SchoolAdmission.Application.Features.FeesStructureDetails.Queries;
public record GetFeesStructureByIdQuery(int Id)
    : IRequest<FeesStructureDetail?>;