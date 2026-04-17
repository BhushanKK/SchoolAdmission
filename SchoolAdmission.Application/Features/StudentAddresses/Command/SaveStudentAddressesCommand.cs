using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.StudentAddresses.Commands;
public class SaveStudentAddressesCommand : StudentAddressesDto, IRequest<ApiResponse<int>>;

