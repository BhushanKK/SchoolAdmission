using MediatR;
using SchoolAdmission.Application.Dtos;

namespace SchoolAdmission.Application.Features.CasteMasters.Queries;

public record GetCasteMasterByIdQuery(int Id)
    : IRequest<CasteMasterDto?>;