using MediatR;
using AutoMapper;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Application.Features.CasteMasters.Commands;
public class CreateCasteMasterCommandHandler(IMapper mapper,
    ApplicationDbContext context) : IRequestHandler<CreateCasteMasterCommand, int>
{
    public async Task<int> Handle(CreateCasteMasterCommand request,CancellationToken cancellationToken)
    {
        var casteMaster = mapper.Map<CasteMaster>(request);
        await context.CasteMasters.AddAsync(casteMaster, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return casteMaster.CasteId;
    }
}