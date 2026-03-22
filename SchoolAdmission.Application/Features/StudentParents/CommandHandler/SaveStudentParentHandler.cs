using MediatR;
using SchoolAdmission.Infrastructure.Interfaces;
using SchoolAdmission.Domain.Entities;

public class SaveStudentParentHandler(IStudentParentsRepository repo)
    : IRequestHandler<SaveStudentParentCommand, int>
{
    public async Task<int> Handle(SaveStudentParentCommand request, CancellationToken cancellationToken)
    {
        var entity = new StudentParents
        {
            ParentId = request.ParentId,
            StudentId = request.StudentId,
            FatherName = request.FatherName,
            MotherName = request.MotherName,
            GrandFatherName = request.GrandFatherName,
            ParentName = request.ParentName,
            ContactNo = request.ContactNo,
            EmailId = request.EmailId,
            Income = request.Income,
            Occupation = request.Occupation
        };

        return await repo.SaveStudentParentUsingSpAsync(request, cancellationToken);
    }
}