using MediatR;
using SchoolAdmission.Application.Dtos;

namespace SchoolAdmission.Application.Features.StandardMasters.Queries;

public record GetAllStandardMastersQuery()
    : IRequest<List<StandardMasterDto>>;