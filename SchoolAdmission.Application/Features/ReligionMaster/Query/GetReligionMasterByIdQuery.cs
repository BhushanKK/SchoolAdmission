using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.ReligionMasters.Queries;

public record GetReligionMasterByIdQuery(int Id)
    : IRequest<ApiResponse<ReligionMasterQueryDto?>>;