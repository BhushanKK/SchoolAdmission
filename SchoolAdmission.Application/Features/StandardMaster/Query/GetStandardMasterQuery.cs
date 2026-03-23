using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.StandardMasters.Queries;

public record GetStandardMasterByIdQuery(int Id)
    : IRequest<ApiResponse<StandardMasterQueryDto?>>;
