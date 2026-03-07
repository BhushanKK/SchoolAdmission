using MediatR;
using AutoMapper;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Application.Features.DivisionMasters.Commands;
public class CreateDivisionMasterCommandHandler(IMapper mapper,
    ApplicationDbContext context) : IRequestHandler<CreateDivisionMasterCommand, int>
{
    public async Task<int> Handle(CreateDivisionMasterCommand request,CancellationToken cancellationToken)
    {
        var DivisionMaster = mapper.Map<DivisionMaster>(request);

        await context.DivisionMasters.AddAsync(DivisionMaster, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return DivisionMaster.DivisionId;
    }
}