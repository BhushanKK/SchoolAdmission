using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.Entities;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.StudentDetailsSteps.Commands;

public class CreateStudentDetailsStepsCommand :  StudentDetailsStep,IRequest<ApiResponse<Guid>>;
