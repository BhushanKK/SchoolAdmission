using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;

public class SaveStudentFeesHandler(IStudentFeesRepository repo)
    : IRequestHandler<SaveStudentFeesCommand, ApiResponse<int>>
{
    public async Task<ApiResponse<int>> Handle(SaveStudentFeesCommand request, CancellationToken cancellationToken)
    {
        var dto = new StudentFeesDto
        {
            FeeId = request.FeeId,
            StudentId = request.StudentId,
            PreviousYearFee = request.PreviousYearFee,
            PreviousYearFeePaid = request.PreviousYearFeePaid,
            IsBusRequired = request.IsBusRequired,
            BusFee = request.BusFee,
            BusFeePaid = request.BusFeePaid,
            FeeExemption = request.FeeExemption
        };

        int result = await repo.SaveStudentFeesAsync(dto, cancellationToken);
        if(result>0)
        {
            return new ApiResponse<int>
            {
                Success = true,
                Data = result,
                Message = MessageHelper.CreatedSuccessfully(EntityEnum.StudentFees)
            };
        }
        else
        {
            return new ApiResponse<int>
            {
                Success = false,
                Message = MessageHelper.InternalServerError(EntityEnum.StudentFees)
            };
        }
    }
}
