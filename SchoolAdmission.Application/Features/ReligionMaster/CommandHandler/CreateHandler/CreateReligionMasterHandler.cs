using MediatR;
using AutoMapper;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Application.Features.Religions.Commands;
public class CreateReligionMasterHandler(IMapper mapper,
    ApplicationDbContext context) : IRequestHandler<CreateReligionMasterCommand, int>
{
    public async Task<int> Handle(CreateReligionMasterCommand request,CancellationToken cancellationToken)
    {
        var ReligionMaster = mapper.Map<ReligionMaster>(request);

        await context.ReligionMasters.AddAsync(ReligionMaster, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return ReligionMaster.ReligionId;
    }
}