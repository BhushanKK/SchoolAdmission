/***using System.Net;
using MediatR;
using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.StudentDetails.Queries;

public class GetAllStudentDetailsHandler(IStudentDetailsRepository repository)
    : IRequestHandler<GetAllStudentDetailsQuery, ApiResponse<List<StudentDetails>>>
{
    public async Task<ApiResponse<List<StudentDetails>>> Handle(GetAllStudentDetailsQuery request, 
    CancellationToken cancellationToken)
    {
        var data = await repository.GetAllAsync(cancellationToken);

        return ApiResponse<List<StudentDetails>>.SuccessResponse(data.Select(x => new StudentDetails
        {
            StudentId = x.StudentId,
            
        }).ToList(), MessageHelper.RetrievedSuccessfully(EntityEnum.StudentDetails), HttpStatusCode.OK.GetHashCode());
    }
}
***/