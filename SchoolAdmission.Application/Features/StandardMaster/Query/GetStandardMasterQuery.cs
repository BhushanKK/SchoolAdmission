using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.StandardMasters.Queries;

public record GetStandardMasterByIdQuery(int Id)
    : IRequest<ApiResponse<StandardMasterQueryDto?>>;
