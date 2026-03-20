using MediatR;
using SchoolAdmission.Domain;

namespace SchoolAdmission.Application.Features.Religions.Queries;

public record GetReligionMasterByIdQuery(int Id)
    : IRequest<ReligionMaster?>;