using System.Net;
using MediatR;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.StudentDetails.Queries;

public class GetAllStudentDetailsHandler(IStudentDetailsViewRepository repository)
    : IRequestHandler<GetAllStudentDetailsQuery, ApiResponse<List<StudentDetailsView>>>
{
    public async Task<ApiResponse<List<StudentDetailsView>>> Handle(GetAllStudentDetailsQuery request, 
    CancellationToken cancellationToken)
    {
        var data = await repository.GetAllAsync(cancellationToken);

        return ApiResponse<List<StudentDetailsView>>.SuccessResponse(data.Select(x => new StudentDetailsView
        {
            StudentId = x.StudentId,
            
        }).ToList(), MessageHelper.RetrievedSuccessfully(EntityEnum.StudentDetails), HttpStatusCode.OK.GetHashCode());
    }
}
