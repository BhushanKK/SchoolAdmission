using MediatR;
using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.DivisionMasters.Queries;

public record GetAllDivisionMastersQuery()
    : IRequest<ApiResponse<List<DivisionMaster>>>;