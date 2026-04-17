using MediatR;
using SchoolAdmission.Domain;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.StandardMasters.Queries;

public record GetAllStandardMasterQuery()
    : IRequest<ApiResponse<List<StandardMaster>>>;
