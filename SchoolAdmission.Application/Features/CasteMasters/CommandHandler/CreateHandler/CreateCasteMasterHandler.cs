using MediatR;
using SchoolAdmission.Application.Common.Interfaces;
using SchoolAdmission.Domain;

namespace SchoolAdmission.Application.Features.CasteMasters.Commands;

public class CreateCasteMasterHandler(ICasteMasterRepository repository) : IRequestHandler<CreateCasteMasterCommand, int>
{

    public async Task<int> Handle(
        CreateCasteMasterCommand request,
        CancellationToken cancellationToken)
    {
        var entity = new CasteMaster
        {
            CategoryId = request.CategoryId,
            Caste = request.Caste
        };

        await repository.AddAsync(entity);
        await repository.SaveChangesAsync();

        return entity.CasteId;
    }
}