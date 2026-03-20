using MediatR;
using AutoMapper;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Application.Features.SchoolMasters.Commands;

public class CreateSchoolMasterHandler(IMapper mapper,
    ApplicationDbContext context) : IRequestHandler<CreateSchoolMasterCommand, int>
{
    public async Task<int> Handle(CreateSchoolMasterCommand request,CancellationToken cancellationToken)
    {
        var SchoolMaster = mapper.Map<SchoolMaster>(request);
        await context.SchoolMasters.AddAsync(SchoolMaster, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return SchoolMaster.SchoolId;
    }
}