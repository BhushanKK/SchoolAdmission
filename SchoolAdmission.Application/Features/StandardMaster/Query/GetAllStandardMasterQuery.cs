using MediatR;
using SchoolAdmission.Domain;

namespace SchoolAdmission.Application.Features.StandardMasters.Queries;

public record GetAllStandardMastersQuery()
    : IRequest<List<StandardMaster>>;