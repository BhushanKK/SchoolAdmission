using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.DivisionMasters.Queries;

public record GetDivisionMasterByIdQuery(int Id) : IRequest<ApiResponse<DivisionMasterQueryDto?>>;
