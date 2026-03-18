using MediatR;
using SchoolAdmission.Domain;

namespace SchoolAdmission.Application.Features.DivisionMasters.Queries;

public record GetAllDivisionMastersQuery()
    : IRequest<List<DivisionMaster>>;