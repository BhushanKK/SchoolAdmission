using MediatR;
using SchoolAdmission.Infrastructure.Interfaces;
using SchoolAdmission.Domain.Entities;

public class SaveStudentAddressesHandler(IStudentAddressesRepository repo)
    : IRequestHandler<SaveStudentAddressesCommand, int>
{
    public async Task<int> Handle(SaveStudentAddressesCommand request, CancellationToken cancellationToken)
    {
        var entity = new StudentAddresses
        {
            StudentId = request.StudentId,
            AddressType = request.AddressType,
            Village = request.Village,
            City = request.City,
            Taluka = request.Taluka,
            District = request.District,
            State = request.State,
            Country = request.Country,
            Pincode = request.Pincode,
            Landmark = request.Landmark
        };

        return await repo.SaveStudentAddressesAsync(request, cancellationToken);
    }
}
