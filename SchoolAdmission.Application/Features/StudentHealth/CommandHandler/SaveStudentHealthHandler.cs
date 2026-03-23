using MediatR;
using SchoolAdmission.Infrastructure.Interfaces;
using SchoolAdmission.Domain.Entities;


public class SaveStudentHealthHandler(IStudentHealthRepository repo)
    : IRequestHandler<SaveStudentHealthCommand, int>
{
    public async Task<int> Handle(SaveStudentHealthCommand request, CancellationToken cancellationToken)
    {
        var entity = new StudentHealth
        {
            HealthId = request.HealthId,
            StudentId = request.StudentId,
            Height = request.Height,
            Weight = request.Weight,
            HandicappedTypeId = request.HandicappedTypeId
        };

        return await repo.SaveStudentHealthAsync(request, cancellationToken);
    }
}
