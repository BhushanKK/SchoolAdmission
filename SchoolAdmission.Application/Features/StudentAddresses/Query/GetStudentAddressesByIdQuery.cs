using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.StudentAddress.Queries;

public record GetStudentAddressByStudentIdQuery(Guid StudentId)
    : IRequest<ApiResponse<StudentAddressesQueryDto?>>;