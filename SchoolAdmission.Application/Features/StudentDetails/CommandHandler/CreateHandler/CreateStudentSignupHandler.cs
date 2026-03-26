using MediatR;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Application.Features.StudentDetails.Commands;
using SchoolAdmission.Domain.Entities;
using SchoolAdmission.Domain.Utils;
public class CreateStudentSignupHandler(ApplicationDbContext context)
: IRequestHandler<CreateStudentSignUpCommand, ApiResponse<Guid>>
{
    public async Task<ApiResponse<Guid>> Handle(CreateStudentSignUpCommand request, CancellationToken cancellationToken)
    {
        var studentSignUp = new StudentDetails
        {
            FirstName = request.FirstName,
            MiddleName = request.MiddleName,
            LastName = request.LastName
        };
        await context.StudentDetails.AddAsync(studentSignUp, cancellationToken);
        var studentId = studentSignUp.StudentId;

        var userLogin = new UsersLogin
        {
            StudentId = studentId,
            EmailId = request.EmailId!,
            MobileNo = request.MobileNo!,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.PasswordHash),
            RoleId = 2,
            IsActive = true,
            CreatedDate = DateTime.UtcNow
        };

        await context.UsersLogins.AddAsync(userLogin, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        if (studentId != Guid.Empty)
        {
            return ApiResponse<Guid>.SuccessResponse
            (
                studentId,
                MessageHelper.CreatedSuccessfully(EntityEnum.StudentAddresses),
                System.Net.HttpStatusCode.Created.GetHashCode()
            );
        }
        return ApiResponse<Guid>.FailureResponse(MessageHelper.InternalServerError(EntityEnum.StudentAddresses), System.Net.HttpStatusCode.InternalServerError.GetHashCode());
    }
}
