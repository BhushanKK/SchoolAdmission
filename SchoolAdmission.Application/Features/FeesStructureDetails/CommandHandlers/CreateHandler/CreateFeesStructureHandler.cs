using MediatR;
using AutoMapper;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Application.Features.FeesStructureDetails.Commands;
public class CreateFeesStructureHandler(IMapper mapper,
    ApplicationDbContext context) : IRequestHandler<CreateFeesStructureCommand, int>
{
    public async Task<int> Handle(CreateFeesStructureCommand request,CancellationToken cancellationToken)
    {
        var ReligionMaster = mapper.Map<FeesStructureDetails>(request);

        await context.FeesStructureDetails.AddAsync(ReligionMaster, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return ReligionMaster.FeeId;
    }
}