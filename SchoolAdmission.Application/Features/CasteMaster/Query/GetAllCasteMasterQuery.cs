using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.CasteMasters.Queries;

public record GetAllCasteMasterQuery()
    : IRequest<ApiResponse<List<CasteMasterQueryDto>>>;
