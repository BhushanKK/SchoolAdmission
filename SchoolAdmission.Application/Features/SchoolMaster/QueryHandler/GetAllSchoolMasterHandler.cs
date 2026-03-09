using MediatR;
//using SchoolAdmission.Application.Interfaces;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.SchoolMasters.Queries;

public class GetAllSchoolMasterHandler 
    : IRequestHandler<GetAllSchoolMastersQuery, List<SchoolMasterQueryDto>>
{
    private readonly ISchoolMasterRepository _repository;

    public GetAllSchoolMasterHandler(ISchoolMasterRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<SchoolMasterQueryDto>> Handle(
        GetAllSchoolMastersQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync(cancellationToken);
    }
}