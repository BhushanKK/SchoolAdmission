using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.Entities;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.StudentSubjectChoice.Queries;

public record GetAllStudentSubjectChoiceQuery()
    : IRequest<ApiResponse<List<StudentSubjectChoiceQueryDto>>>;