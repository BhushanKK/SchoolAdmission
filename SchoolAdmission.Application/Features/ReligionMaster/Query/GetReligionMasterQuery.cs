using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.Religions.Queries;

public record GetReligionMasterByIdQuery(int Id)
    : IRequest<ReligionMasterQueryDto?>;