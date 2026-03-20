using MediatR;
using SchoolAdmission.Domain;

namespace SchoolAdmission.Application.Features.SchoolMasters.Queries;

public record GetSchoolMasterByIdQuery(int Id)
    : IRequest<SchoolMaster?>;