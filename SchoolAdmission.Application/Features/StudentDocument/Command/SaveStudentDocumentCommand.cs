using MediatR;
using SchoolAdmission.Domain.Dtos;

public class SaveStudentDocumentCommand : StudentDocumentDto, IRequest<int>;
