using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.SchoolMasters.Queries;

public record GetSchoolMasterByIdQuery(int Id)
    : IRequest<SchoolMasterQueryDto?>;