using MediatR;
//using SchoolAdmission.Application.Interfaces;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.DivisionMasters.Queries;

public class GetDivisionMasterByIdHandler 
    : IRequestHandler<GetDivisionMasterByIdQuery, DivisionMasterQueryDto?>
{
    private readonly IDivisionMasterRepository _repository;

    public GetDivisionMasterByIdHandler(IDivisionMasterRepository repository)
    {
        _repository = repository;
    }

    public async Task<DivisionMasterQueryDto?> Handle(
        GetDivisionMasterByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.GetByIdWithAsync(request.Id, cancellationToken);
    }
}