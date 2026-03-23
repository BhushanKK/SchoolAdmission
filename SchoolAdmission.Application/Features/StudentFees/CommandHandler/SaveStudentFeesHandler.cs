using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Infrastructure.Interfaces;

public class SaveStudentFeesHandler(IStudentFeesRepository repo)
    : IRequestHandler<SaveStudentFeesCommand, int>
{
    public async Task<int> Handle(SaveStudentFeesCommand request, CancellationToken cancellationToken)
    {
        var dto = new StudentFeesDto
        {
            FeeId = request.FeeId,
            StudentId = request.StudentId,
            PreviousYearFee = request.PreviousYearFee,
            PreviousYearFeePaid = request.PreviousYearFeePaid,
            IsBusRequired = request.IsBusRequired,
            BusFee = request.BusFee,
            BusFeePaid = request.BusFeePaid,
            FeeExemption = request.FeeExemption
        };

        return await repo.SaveStudentFeesAsync(dto, cancellationToken);
    }
}
