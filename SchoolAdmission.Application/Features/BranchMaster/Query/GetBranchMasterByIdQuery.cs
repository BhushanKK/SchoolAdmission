using MediatR;
using SchoolAdmission.Domain;

namespace SchoolAdmission.Application.Features.BranchMasters.Queries;
public record GetBranchMasterByIdQuery(int Id)
    : IRequest<BranchMaster?>;