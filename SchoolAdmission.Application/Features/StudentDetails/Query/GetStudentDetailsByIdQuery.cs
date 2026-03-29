using MediatR;
using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Entities;

public record GetStudentByIdQuery(Guid Id) 
    : IRequest<ApiResponse<StudentDetails>>;