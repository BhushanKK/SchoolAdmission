using MediatR;
using SchoolAdmission.Domain;

namespace SchoolAdmission.Application.Features.DivisionMasters.Queries;
public record GetDivisionMasterByIdQuery(int Id) : IRequest<DivisionMaster?>;