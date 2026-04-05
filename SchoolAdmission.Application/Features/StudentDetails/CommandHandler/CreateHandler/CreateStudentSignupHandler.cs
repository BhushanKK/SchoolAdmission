using MediatR;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Application.Features.StudentDetails.Commands;
using SchoolAdmission.Domain.Entities;
using SchoolAdmission.Domain.Utils;
using static SchoolAdmission.Domain.Utils.CommanEnums;

public class CreateStudentSignupHandler : IRequestHandler<CreateStudentSignUpCommand, ApiResponse<Guid>>
{
    private readonly ApplicationDbContext _context;
    private readonly IEmailService _emailService;
    public CreateStudentSignupHandler(ApplicationDbContext context, IEmailService emailService)
    {
        _context = context;
        _emailService = emailService;
    }

    public async Task<ApiResponse<Guid>> Handle(CreateStudentSignUpCommand request, CancellationToken cancellationToken)
    {
        var studentSignUp = new StudentDetails
        {
            FirstName = request.FirstName,
            MiddleName = request.MiddleName,
            LastName = request.LastName,
            SchoolId = request.SchoolId,
        };
        await _context.StudentDetails.AddAsync(studentSignUp, cancellationToken);

        var studentId = studentSignUp.StudentId;

        var userLogin = new UsersLogin
        {
            StudentId = studentId,
            EmailId = request.EmailId!,
            MobileNo = request.MobileNo!,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.PasswordHash),
            RoleId = RoleEnum.Student.GetHashCode(),
            IsActive = false,
            CreatedDate = DateTime.UtcNow,
        };

        await _context.UsersLogins.AddAsync(userLogin, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        if (studentId != Guid.Empty)
        {
            await SendWelcomeEmailAsync(userLogin, studentSignUp, request.PasswordHash!);
            return ApiResponse<Guid>.SuccessResponse(
                studentId,
                $"{MessageHelper.CreatedSuccessfully(EntityEnum.StudentAddresses)} Please check your email for further instructions.",
                System.Net.HttpStatusCode.Created.GetHashCode()
            );
        }

        return ApiResponse<Guid>.FailureResponse(
            MessageHelper.InternalServerError(EntityEnum.StudentAddresses),
            System.Net.HttpStatusCode.InternalServerError.GetHashCode()
        );
    }

    private async Task SendWelcomeEmailAsync(UsersLogin userLogin, StudentDetails student, string rawPassword)
    {
        try
        {
            var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "EmailTemplates", "studentRegistration.html");

            if (!File.Exists(templatePath))
                throw new FileNotFoundException($"Template not found: {templatePath}");

            var htmlBody = await File.ReadAllTextAsync(templatePath);

            htmlBody = htmlBody
                .Replace("{{FirstName}}", student.FirstName ?? string.Empty)
                .Replace("{{LastName}}", student.LastName ?? string.Empty)
                .Replace("{{SchoolId}}", student.SchoolId.ToString())
                .Replace("{{EmailId}}", userLogin.EmailId ?? "N/A")
                .Replace("{{MobileNo}}", string.IsNullOrWhiteSpace(userLogin.MobileNo) ? "N/A" : userLogin.MobileNo)
                .Replace("{{Password}}", string.IsNullOrWhiteSpace(rawPassword) ? "N/A" : rawPassword);

            await _emailService.SendEmailAsync(
                userLogin.EmailId!,
                "Welcome to Our School Admission Portal",
                htmlBody
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Email sending failed: {ex.Message}");
        }
    }
}