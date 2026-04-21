using System.Net;
using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.StudentParents.Queries;

public class GetStudentParentsByStudentIdHandler(IStudentParentsRepository repository)
    : IRequestHandler<GetStudentParentsByStudentIdQuery, ApiResponse<StudentParentsQueryDto?>>
{
    public async Task<ApiResponse<StudentParentsQueryDto?>> Handle(
        GetStudentParentsByStudentIdQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await repository.GetByStudentIdAsync(request.StudentId, cancellationToken);

        if (entity is null)
            return ApiResponse<StudentParentsQueryDto?>.FailureResponse(
                MessageHelper.NotFound(EntityEnum.StudentParents, request.StudentId),
                HttpStatusCode.NotFound.GetHashCode());

        return ApiResponse<StudentParentsQueryDto?>.SuccessResponse(
            new StudentParentsQueryDto
            {
                ParentId = entity.ParentId,
                StudentId = entity.StudentId,
                FatherName = entity.FatherName,
                MotherName = entity.MotherName,
                GrandFatherName = entity.GrandFatherName,
                ParentName = entity.ParentName,
                ContactNo = entity.ContactNo,
                EmailId = entity.EmailId,
                Income = entity.Income,
                Occupation = entity.Occupation
            },
            MessageHelper.RetrievedSuccessfully(EntityEnum.StudentParents),
            HttpStatusCode.OK.GetHashCode());
    }
}