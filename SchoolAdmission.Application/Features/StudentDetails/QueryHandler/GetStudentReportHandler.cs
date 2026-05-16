using System.Net;
using MediatR;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;
using SchoolAdmission.Domain.ResponseModels;
using SchoolAdmission.Domain.ViewModels;

namespace SchoolAdmission.Application.Features.StudentDetails.Queries;

public class GetStudentReportHandler(IStudentDetailsViewRepository repository)
    : IRequestHandler<GetStudentReportQuery, ApiResponse<StudentDetailsView>>
{
    public async Task<ApiResponse<StudentDetailsView>> Handle(GetStudentReportQuery request, 
    CancellationToken cancellationToken)
    {
        var studentDetails = await repository.GetStudentReportAsync(request.StudentId, cancellationToken);

        return ApiResponse<StudentDetailsView>.SuccessResponse
        (
            studentDetails,
            MessageHelper.RetrievedSuccessfully(EntityEnum.StudentDetails), 
            HttpStatusCode.OK.GetHashCode()
        );
    }
}
