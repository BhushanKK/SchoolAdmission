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
            return new ApiResponse<int>
            {
                Success = true,
                Data = result,
                Message = MessageHelper.CreatedSuccessfully(EntityEnum.StudentAddresses)
            };
        }
        
        return new ApiResponse<int>
        {
            Success = false,
            Message = MessageHelper.InternalServerError(EntityEnum.StudentAddresses)
        };        
    }
}
