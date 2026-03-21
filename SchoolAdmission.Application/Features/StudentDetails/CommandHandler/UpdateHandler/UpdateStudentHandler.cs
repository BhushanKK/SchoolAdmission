using MediatR;
using SchoolAdmission.Application.Features.StudentDetails.Commands;
using SchoolAdmission.Infrastructure.Interfaces;

public class UpdateStudentCommandHandler(IStudentUpdateRepository repo)
    : IRequestHandler<UpdateStudentCommand, int>
{
    public async Task<int> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        return await repo.UpdateStudentUsingSpAsync(request, cancellationToken);
    }
}