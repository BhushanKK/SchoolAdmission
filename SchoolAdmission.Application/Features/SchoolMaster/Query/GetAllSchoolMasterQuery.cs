using MediatR;
using SchoolAdmission.Domain;

namespace SchoolAdmission.Application.Features.SchoolMasters.Queries;

public record GetAllSchoolMastersQuery() : IRequest<List<SchoolMaster>>;
