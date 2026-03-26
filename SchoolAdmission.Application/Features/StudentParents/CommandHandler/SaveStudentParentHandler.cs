using MediatR;
using SchoolAdmission.Infrastructure.Interfaces;
using SchoolAdmission.Domain.Dto;
using SchoolAdmission.Domain.Utils;

public class SaveStudentParentHandler(IStudentParentsRepository repo)
    : IRequestHandler<SaveStudentParentCommand, ApiResponse<int>>
{
    public async Task<ApiResponse<int>> Handle(SaveStudentParentCommand request, CancellationToken cancellationToken)
    {
        int result = await repo.SaveStudentParentsAsync(request, cancellationToken);
        if (result > 0)
        {
            return new ApiResponse<int>
            {
                Success = true,
                Data = result,
                Message = MessageHelper.CreatedSuccessfully(EntityEnum.StudentParents)
            };
        }

        return new ApiResponse<int>
        {
            Success = false,
            Message = MessageHelper.InternalServerError(EntityEnum.StudentParents)
        };
    }
}
