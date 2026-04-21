using System.Net;
using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.StudentHealth.Queries;

public class GetStudentHealthByStudentIdHandler(IStudentHealthRepository repository)
    : IRequestHandler<GetStudentHealthByStudentIdQuery, ApiResponse<StudentHealthQueryDto?>>
{
    public async Task<ApiResponse<StudentHealthQueryDto?>> Handle(
        GetStudentHealthByStudentIdQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await repository.GetByStudentIdAsync(request.StudentId, cancellationToken);

        if (entity is null)
            return ApiResponse<StudentHealthQueryDto?>.FailureResponse(
                MessageHelper.NotFound(EntityEnum.StudentHealth, request.StudentId),
                HttpStatusCode.NotFound.GetHashCode());

        return ApiResponse<StudentHealthQueryDto?>.SuccessResponse(
            new StudentHealthQueryDto
            {
                HealthId = entity.HealthId,
                StudentId = entity.StudentId,
                Height = entity.Height,
                Weight = entity.Weight,
                HandicappedTypeId = entity.HandicappedTypeId
            },
            MessageHelper.RetrievedSuccessfully(EntityEnum.StudentHealth),
            HttpStatusCode.OK.GetHashCode());
    }
}