using SchoolAdmission.Domain.Entities;
using static SchoolAdmission.Domain.Utils.CommanEnums;

namespace SchoolAdmission.Infrastructure.Interfaces;

public interface IStudentSubjectChoiceRepository
{
    Task<List<StudentSubjectChoice>> GetAllAsync(CancellationToken cancellationToken);

    Task<StudentSubjectChoice?> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task AddAsync(StudentSubjectChoice studentSubjectChoice, CancellationToken cancellationToken);

    Task UpdateAsync(StudentSubjectChoice studentSubjectChoice, CancellationToken cancellationToken);

    Task DeleteAsync(StudentSubjectChoice studentSubjectChoice, CancellationToken cancellationToken);

    Task<bool> IsExistsAsync(Guid studentId,int subjectId,OperationType operation,int ChoiceId,CancellationToken cancellationToken);

}