/***using System.Net;
using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.StudentDetails.Queries;

public class GetStudentDetailsByIdHandler(IStudentDetailsRepository repository)
    : IRequestHandler<GetStudentDetailsByIdQuery, ApiResponse<StudentDetailsQueryDto?>>
{
    public async Task<ApiResponse<StudentDetailsQueryDto?>> Handle(
        GetStudentDetailsByIdQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id,cancellationToken);

        if (entity == null)
            return ApiResponse<StudentDetailsQueryDto?>.FailureResponse("Student Details not found", 404);

        return ApiResponse<StudentDetailsQueryDto?>.SuccessResponse(new StudentDetailsQueryDto
        {
            StudentId= entity.StudentId,
           
        }, MessageHelper.RetrievedSuccessfully(EntityEnum.StudentDetails), HttpStatusCode.OK.GetHashCode());
    }
}
***/
          
