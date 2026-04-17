using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.SchoolMasters.Queries;

public record GetSchoolMasterByIdQuery(int Id)
    : IRequest<ApiResponse<SchoolMasterQueryDto?>>;
