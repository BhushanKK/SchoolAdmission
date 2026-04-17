using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.ReligionMasters.Queries;

public record GetReligionMasterByIdQuery(int Id)
    : IRequest<ApiResponse<ReligionMasterQueryDto?>>;
