using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.DivisionMasters.Queries;

public record GetAllDivisionMastersQuery()
    : IRequest<List<DivisionMasterQueryDto>>;