using MediatR;
using SchoolAdmission.Domain;

namespace SchoolAdmission.Application.Features.Religions.Queries;

public record GetAllReligionMastersQuery()
    : IRequest<List<ReligionMaster>>;