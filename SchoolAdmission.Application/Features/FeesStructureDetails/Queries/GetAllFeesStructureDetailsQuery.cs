using MediatR;
using SchoolAdmission.Domain;

namespace SchoolAdmission.Application.Features.FeesStructureDetails.Queries;

public record GetAllFeesStructureDetailsQuery()
    : IRequest<List<FeesStructureDetail>>;