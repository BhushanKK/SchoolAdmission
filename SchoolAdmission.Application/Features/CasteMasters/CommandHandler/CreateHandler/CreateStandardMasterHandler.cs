using MediatR;
using AutoMapper;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Application.Features.StandardMasters.Commands;
public class CreateStandardMasterCommandHandler(IMapper mapper,
    ApplicationDbContext context) : IRequestHandler<CreateStandardMasterCommand, int>
{
    public async Task<int> Handle(CreateStandardMasterCommand request,CancellationToken cancellationToken)
    {
        var StandardMaster = mapper.Map<StandardMaster>(request);

        await context.StandardMasters.AddAsync(StandardMaster, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return StandardMaster.StandardId;
    }
}