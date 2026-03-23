using MediatR;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Application.Features.StudentDetails.Commands;
using SchoolAdmission.Domain.Entities;

public class CreateStudentSignupHandler(ApplicationDbContext context) 
: IRequestHandler<CreateStudentSignUpCommand, Guid>
{
    public async Task<Guid> Handle(CreateStudentSignUpCommand request,CancellationToken cancellationToken)
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
        return studentId;
    }
}
