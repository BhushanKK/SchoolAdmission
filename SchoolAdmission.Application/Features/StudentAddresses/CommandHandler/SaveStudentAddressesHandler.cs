using MediatR;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Domain.ResponseModels;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.StudentAddresses.Commands;
public class SaveStudentAddressesHandler(IStudentAddressesRepository repo)
    : IRequestHandler<SaveStudentAddressesCommand, ApiResponse<int>>
{
    public async Task<ApiResponse<int>> Handle(SaveStudentAddressesCommand request, CancellationToken cancellationToken)
    {
        int result = await repo.SaveStudentAddressesAsync(request, cancellationToken);
        if(result>0)
        {
            return ApiResponse<int>.SuccessResponse
            (
                result, 
                MessageHelper.CreatedSuccessfully(EntityEnum.StudentAddresses), 
                System.Net.HttpStatusCode.Created.GetHashCode()
            );
        }
        return ApiResponse<int>.FailureResponse(MessageHelper.InternalServerError(EntityEnum.StudentAddresses), System.Net.HttpStatusCode.InternalServerError.GetHashCode());  
    }
}
