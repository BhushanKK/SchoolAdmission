using MediatR;
using SchoolAdmission.Infrastructure.Interfaces;
using SchoolAdmission.Domain.Dto;
using SchoolAdmission.Domain.Utils;

public class SaveStudentParentHandler(IStudentParentsRepository repo)
    : IRequestHandler<SaveStudentParentCommand, ApiResponse<int>>
{
    public async Task<ApiResponse<int>> Handle(SaveStudentParentCommand request, CancellationToken cancellationToken)
    {
        var dto = new StudentParentsDto
        {
            ParentId = request.ParentId,
            StudentId = request.StudentId,
            FatherName = request.FatherName,
            MotherName = request.MotherName,
            GrandFatherName = request.GrandFatherName,
            ParentName = request.ParentName,
            ContactNo = request.ContactNo,
            EmailId = request.EmailId,
            Income = request.Income,
            Occupation = request.Occupation
        };

        int result = await repo.SaveStudentParentsAsync(dto, cancellationToken);
        if(result>0)
        {
            return new ApiResponse<int>
            {
                Success = true,
                Data = result,
                Message = MessageHelper.CreatedSuccessfully(EntityEnum.StudentParents)
            };
        }
        else
        {
            return new ApiResponse<int>
            {
                Success = false,
                Message = MessageHelper.InternalServerError(EntityEnum.StudentParents)
            };
        }
    }
}
