using MediatR;
using SchoolAdmission.Domain;

namespace SchoolAdmission.Application.Features.StandardMasters.Queries;

public record GetStandardMasterByIdQuery(int Id)
    : IRequest<StandardMaster?>;