using MediatR;
using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.SchoolMasters.Queries;

public class GetAllSchoolMasterHandler(ISchoolMasterRepository repository)
        : IRequestHandler<GetAllSchoolMastersQuery, List<SchoolMaster>>
{
        public async Task<List<SchoolMaster>> Handle(GetAllSchoolMastersQuery request,
            CancellationToken cancellationToken)
        {
            return await repository.GetAllAsync(cancellationToken);
        }
    
}