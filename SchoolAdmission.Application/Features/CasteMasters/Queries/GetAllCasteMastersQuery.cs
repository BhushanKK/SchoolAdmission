using MediatR;
using SchoolAdmission.Domain;

namespace SchoolAdmission.Application.Features.CasteMasters.Queries;

public record GetAllCasteMastersQuery()
    : IRequest<List<CasteMaster>>;