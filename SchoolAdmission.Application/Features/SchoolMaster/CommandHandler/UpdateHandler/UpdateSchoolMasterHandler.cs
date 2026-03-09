using MediatR;
using AutoMapper;

namespace SchoolAdmission.Application.Features.SchoolMasters.Commands;

public class UpdateSchoolMasterCommandHandler 
    : IRequestHandler<UpdateSchoolMasterCommand, bool>
{
    private readonly ISchoolMasterRepository _repository;
    private readonly IMapper _mapper;

    public UpdateSchoolMasterCommandHandler(
        ISchoolMasterRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(
        UpdateSchoolMasterCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _repository.GetEntityByIdAsync(request.SchoolId, cancellationToken);

        if (entity == null)
            return false;

        _mapper.Map(request, entity);

        await _repository.Update(entity, cancellationToken);

        return true;
    }
}