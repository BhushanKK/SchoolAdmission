using MediatR;
using AutoMapper;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Application.Features.FeesStructureDetails.Commands;
public class CreateFeesStructureHandler(IMapper mapper,
    ApplicationDbContext context) : IRequestHandler<CreateFeesStructureDetailCommand, int>
{
    public async Task<int> Handle(CreateFeesStructureDetailCommand request,CancellationToken cancellationToken)
    {
        var ReligionMaster = mapper.Map<FeesStructureDetail>(request);

        await context.FeesStructureDetails.AddAsync(ReligionMaster, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return ReligionMaster.FeeId;
    }
}