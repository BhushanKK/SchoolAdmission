using MediatR;
using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.ReligionMasters.Queries;

public record GetAllReligionMastersQuery()
    : IRequest<ApiResponse<List<ReligionMasterQueryDto>>>;