using MediatR;
using SchoolAdmission.Infrastructure.Interfaces;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.Utils;

public class SaveStudentHealthHandler(IStudentHealthRepository repo)
    : IRequestHandler<SaveStudentHealthCommand, ApiResponse<int>>
{
    public async Task<ApiResponse<int>> Handle(SaveStudentHealthCommand request, CancellationToken cancellationToken)
    {
        var dto = new StudentHealthDto
        {
            HealthId = request.HealthId,
            StudentId = request.StudentId,
            Height = request.Height,
            Weight = request.Weight,
            HandicappedTypeId = request.HandicappedTypeId
        };

        int result = await repo.SaveStudentHealthAsync(dto, cancellationToken);
        if(result>0)
        {
            return new ApiResponse<int>
            {
                Success = true,
                Data = result,
                Message = MessageHelper.CreatedSuccessfully(EntityEnum.StudentHealth)
            };
        }
        else
        {
            return new ApiResponse<int>
            {
                Success = false,
                Message = MessageHelper.InternalServerError(EntityEnum.StudentHealth)
            };
        }
    }
}
