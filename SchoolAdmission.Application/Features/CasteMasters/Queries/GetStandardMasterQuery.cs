using MediatR;
using SchoolAdmission.Application.Dtos;

namespace SchoolAdmission.Application.Features.StandardMasters.Queries;

public record GetStandardMasterByIdQuery(int Id) : IRequest<StandardMasterDto?>;