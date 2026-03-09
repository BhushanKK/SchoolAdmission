using MediatR;
using SchoolAdmission.Domain;

namespace SchoolAdmission.Application.Features.BranchMasters.Queries;

public record GetAllBranchMastersQuery()
    : IRequest<List<BranchMaster>>; 