using MediatR;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Domain.Dtos;

public class SaveStudentAddressesHandler(IStudentAddressesRepository repo)
    : IRequestHandler<SaveStudentAddressesCommand, ApiResponse<int>>
{
    public async Task<ApiResponse<int>> Handle(SaveStudentAddressesCommand request, CancellationToken cancellationToken)
    {
        var dto = new StudentAddressesDto
        {
            StudentId = request.StudentId,
            AddressType = request.AddressType,
            Village = request.Village,
            City = request.City,
            Taluka = request.Taluka,
            District = request.District,
            State = request.State,
            Country = request.Country,
            Pincode = request.Pincode,
            Landmark = request.Landmark
        };

        int result = await repo.SaveStudentAddressesAsync(dto, cancellationToken);
        if(result>0)
        {
            return new ApiResponse<int>
            {
                Success = true,
                Data = result,
                Message = MessageHelper.CreatedSuccessfully(EntityEnum.StudentAddresses)
            };
        }
        else
        {
            return new ApiResponse<int>
            {
                Success = false,
                Message = MessageHelper.InternalServerError(EntityEnum.StudentAddresses)
            };
        }
    }
}
