using System.Net;
using AutoMapper;
using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.StudentDetails.Queries;

public class GetStudentDetailsByIdHandler(IStudentDetailsRepository repository)
    : IRequestHandler<GetStudentByIdQuery, ApiResponse<StudentDetailsQueryDto?>>
{
    public async Task<ApiResponse<StudentDetailsQueryDto?>> Handle(
        GetStudentByIdQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id,cancellationToken);

        if (entity is null)
            return ApiResponse<StudentDetailsQueryDto?>.FailureResponse(MessageHelper.NotFound(EntityEnum.StudentDetails, request.Id), HttpStatusCode.NotFound.GetHashCode());

        return ApiResponse<StudentDetailsQueryDto?>.SuccessResponse(new StudentDetailsQueryDto
        {
            StudentId= entity.StudentId,
            RegistrationNo = entity.RegistrationNo,
            SchoolId = entity.SchoolId,
            AcademicYearId = entity.AcademicYearId,
            FinancialYearId = entity.FinancialYearId,
            FirstName = entity.FirstName,
            MiddleName = entity.MiddleName,
            LastName = entity.LastName,
            Gender = entity.Gender,
            DOB = entity.DOB,
            SaralId = entity.SaralId,
            AadharNo = entity.AadharNo,
            Nationality = entity.Nationality,
            MotherTongue = entity.MotherTongue,
            ReligionId = entity.ReligionId,
            CasteId = entity.CasteId,
            CategoryId = entity.CategoryId,
            IsMinority = entity.IsMinority,
            IsHandicapped = entity.IsHandicapped,
            IsBpl = entity.IsBpl,
            Photo = entity.Photo,
            BranchId = entity.BranchId
        }, MessageHelper.RetrievedSuccessfully(EntityEnum.StudentDetails), HttpStatusCode.OK.GetHashCode());
    }
}

