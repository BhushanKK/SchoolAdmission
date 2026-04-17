using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.CasteMasters.Queries;

public record GetAllCasteMasterQuery()
    : IRequest<ApiResponse<List<CasteMasterQueryDto>>>;
