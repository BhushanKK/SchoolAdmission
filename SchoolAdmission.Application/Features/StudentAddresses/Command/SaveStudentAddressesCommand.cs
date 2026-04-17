using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.StudentAddresses.Commands;
public class SaveStudentAddressesCommand : StudentAddressesDto, IRequest<ApiResponse<int>>;

