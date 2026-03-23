using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.CasteMasters.Queries;

public record GetCasteMasterByIdQuery(int Id)
    : IRequest<ApiResponse<CasteMasterQueryDto?>>;
