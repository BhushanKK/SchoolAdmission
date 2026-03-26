using MediatR;
using SchoolAdmission.Domain.Utils;

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
