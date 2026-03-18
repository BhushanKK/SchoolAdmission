using MediatR;
using SchoolAdmission.Domain;

namespace SchoolAdmission.Application.Features.CasteMasters.Queries;

public record GetCasteMasterByIdQuery(int Id)
    : IRequest<CasteMaster?>;