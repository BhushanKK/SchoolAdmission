using MediatR;
using SchoolAdmission.Application.Common.Interfaces;
using SchoolAdmission.Application.Dtos;

namespace SchoolAdmission.Application.Features.CasteMasters.Queries;

public class GetAllCasteMastersHandler 
    : IRequestHandler<GetAllCasteMastersQuery, List<CasteMasterDto>>
{
    private readonly ICasteMasterRepository _repository;

    public GetAllCasteMastersHandler(ICasteMasterRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<CasteMasterDto>> Handle(
        GetAllCasteMastersQuery request,
        CancellationToken cancellationToken)
    {
        var data = await _repository.GetAllAsync();

        return data.Select(x => new CasteMasterDto
        {
            CasteId = x.CasteId,
            CategoryId = x.CategoryId,
            Caste = x.Caste
        }).ToList();
    }
}