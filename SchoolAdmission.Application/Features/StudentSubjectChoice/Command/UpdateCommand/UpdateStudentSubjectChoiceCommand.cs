using MediatR;
using SchoolAdmission.Domain.Dto;

namespace SchoolAdmission.Application.Features.StudentSubjectChoice.Commands;

public class UpdateStudentSubjectChoiceCommand 
    : StudentSubjectChoiceCommandDto, IRequest<ApiResponse<bool>>;