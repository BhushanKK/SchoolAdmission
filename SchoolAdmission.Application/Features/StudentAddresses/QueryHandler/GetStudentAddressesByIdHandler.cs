using System.Net;
using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.StudentAddress.Queries;

public class GetStudentAddressByStudentIdHandler(IStudentAddressesRepository repository)
    : IRequestHandler<GetStudentAddressByStudentIdQuery, ApiResponse<StudentAddressesQueryDto?>>
{
    public async Task<ApiResponse<StudentAddressesQueryDto?>> Handle(
        GetStudentAddressByStudentIdQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await repository.GetByStudentIdAsync(request.StudentId, cancellationToken);

        if (entity is null)
            return ApiResponse<StudentAddressesQueryDto?>.FailureResponse(
                MessageHelper.NotFound(EntityEnum.StudentAddresses, request.StudentId),
                HttpStatusCode.NotFound.GetHashCode());

        return ApiResponse<StudentAddressesQueryDto?>.SuccessResponse(
            new StudentAddressesQueryDto
            {
                AddressId = entity.AddressId,
                StudentId = entity.StudentId,

                CVillage = entity.CVillage,
                CCity = entity.CCity,
                CTaluka = entity.CTaluka,
                CDistrict = entity.CDistrict,
                CState = entity.CState,
                CCountry = entity.CCountry,
                CPincode = entity.CPincode,
                CLandmark = entity.CLandmark,

                PVillage = entity.PVillage,
                PCity = entity.PCity,
                PTaluka = entity.PTaluka,
                PDistrict = entity.PDistrict,
                PState = entity.PState,
                PCountry = entity.PCountry,
                PPincode = entity.PPincode,
                PLandmark = entity.PLandmark,

                IsSameAddress = entity.IsSameAddress
            },
            MessageHelper.RetrievedSuccessfully(EntityEnum.StudentAddresses),
            HttpStatusCode.OK.GetHashCode());
    }
}