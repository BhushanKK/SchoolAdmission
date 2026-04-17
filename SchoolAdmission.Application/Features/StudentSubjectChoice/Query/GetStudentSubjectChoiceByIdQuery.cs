using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.StudentSubjectChoice.Queries;

public record GetStudentSubjectChoiceByIdQuery(int Id)
    : IRequest<ApiResponse<StudentSubjectChoiceQueryDto?>>;