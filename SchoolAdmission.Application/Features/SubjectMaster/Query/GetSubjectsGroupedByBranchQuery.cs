using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.ResponseModels;

public record GetSubjectsGroupedByBranchQuery(int BranchId)
    : IRequest<ApiResponse<GroupedSubjectsDto>>;