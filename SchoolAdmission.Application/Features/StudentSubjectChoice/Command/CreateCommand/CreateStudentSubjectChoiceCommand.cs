using MediatR;
using SchoolAdmission.Domain.Dto;

namespace SchoolAdmission.Application.Features.StudentSubjectChoice.Commands;

public class CreateStudentSubjectChoiceCommand 
    : StudentSubjectChoiceCommandDto, IRequest<ApiResponse<int>>;