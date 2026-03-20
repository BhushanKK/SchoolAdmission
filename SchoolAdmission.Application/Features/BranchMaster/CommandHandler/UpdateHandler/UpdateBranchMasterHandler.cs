using MediatR;
using AutoMapper;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.BranchMasters.Commands;

public class UpdateBranchMasterHandler(IBranchMasterRepository repository,IMapper mapper)
    : IRequestHandler<UpdateBranchMasterCommand, bool>
{
    public async Task<bool> Handle(UpdateBranchMasterCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.BranchId, cancellationToken);

        if (entity == null)
            return false;
    
        entity.BranchId = request.BranchId;

        mapper.Map(request, entity);

        await repository.UpdateAsync(entity, cancellationToken);

        return true;
    }
}