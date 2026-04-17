using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.CasteMasters.Queries;

public record GetCasteMasterByIdQuery(int Id)
    : IRequest<ApiResponse<CasteMasterQueryDto?>>;
