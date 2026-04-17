using MediatR;
using SchoolAdmission.Domain.Dto;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.StudentSubjectChoice.Commands;

public class UpdateStudentSubjectChoiceCommand 
    : StudentSubjectChoiceCommandDto, IRequest<ApiResponse<bool>>;