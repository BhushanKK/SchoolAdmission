using MediatR;
using SchoolAdmission.Domain.Dto;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.StudentSubjectChoice.Commands;

public class CreateStudentSubjectChoiceCommand 
    : List<StudentSubjectChoiceCommandDto>, IRequest<ApiResponse<int>>;