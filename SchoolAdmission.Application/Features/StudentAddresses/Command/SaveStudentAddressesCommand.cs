using MediatR;
using SchoolAdmission.Domain.Dtos;
public class SaveStudentAddressesCommand : StudentAddressesDto, IRequest<ApiResponse<int>>;

