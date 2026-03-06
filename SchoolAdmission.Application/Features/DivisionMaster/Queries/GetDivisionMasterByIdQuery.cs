using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.DivisionMasters.Queries;

public record GetDivisionMasterByIdQuery(int Id)
    : IRequest<DivisionMasterQueryDto?>;