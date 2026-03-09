using MediatR;
//using SchoolAdmission.Application.Interfaces;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.SchoolMasters.Queries;

public class GetSchoolMasterByIdHandler 
    : IRequestHandler<GetSchoolMasterByIdQuery, SchoolMasterQueryDto?>
{
    private readonly ISchoolMasterRepository _repository;

    public GetSchoolMasterByIdHandler(ISchoolMasterRepository repository)
    {
        _repository = repository;
    }

    public async Task<SchoolMasterQueryDto?> Handle(
        GetSchoolMasterByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id, cancellationToken);
    }
}