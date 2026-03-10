using MediatR;
using AutoMapper;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Application.Features.BranchMasters.Commands;

public class CreateBranchMasterHandler(IMapper mapper,
    ApplicationDbContext context) : IRequestHandler<CreateBranchMasterCommand, int>
{
    public async Task<int> Handle(CreateBranchMasterCommand request,CancellationToken cancellationToken)
    {
        var branchMaster = mapper.Map<BranchMaster>(request);
        await context.BranchMasters.AddAsync(branchMaster, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return branchMaster.BranchId;
    }
}