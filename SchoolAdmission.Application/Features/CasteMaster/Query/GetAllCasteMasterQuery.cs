using MediatR;
using SchoolAdmission.Domain;

namespace SchoolAdmission.Application.Features.CasteMasters.Queries;

public record GetAllCasteMasterQuery()
    : IRequest<List<CasteMaster>>;