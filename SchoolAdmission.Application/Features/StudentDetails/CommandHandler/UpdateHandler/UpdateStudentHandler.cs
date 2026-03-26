using MediatR;
using SchoolAdmission.Application.Features.StudentDetails.Commands;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;

public class UpdateStudentCommandHandler(IStudentUpdateRepository repo)
    : IRequestHandler<UpdateStudentCommand, ApiResponse<int>>
{
    public async Task<ApiResponse<int>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        var result = await repo.UpdateStudentUsingSpAsync(request, cancellationToken);
        return ApiResponse<int>.SuccessResponse
        (
            result,
            MessageHelper.UpdatedSuccessfully(EntityEnum.StudentAddresses),
            System.Net.HttpStatusCode.OK.GetHashCode()
        );
    }
}
