using MediatR;
using SchoolAdmission.Application.Common.Interfaces;
using SchoolAdmission.Domain;

namespace SchoolAdmission.Application.Features.CasteMasters.Commands;

public class CreateCasteMasterHandler
    : IRequestHandler<CreateCasteMasterCommand, int>
{
    private readonly ICasteMasterRepository _repository;

    public CreateCasteMasterHandler(ICasteMasterRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(
        CreateCasteMasterCommand request,
        CancellationToken cancellationToken)
    {
        var entity = new CasteMaster
        {
            CategoryId = request.CategoryId,
            Caste = request.Caste
        };

        await _repository.AddAsync(entity);
        await _repository.SaveChangesAsync();

        return entity.CasteId;
    }
}