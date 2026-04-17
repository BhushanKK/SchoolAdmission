using MediatR;
using SchoolAdmission.Domain.Dto;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.StudentSubjectChoice.Commands;

public class CreateStudentSubjectChoiceCommand 
    : StudentSubjectChoiceCommandDto, IRequest<ApiResponse<int>>;