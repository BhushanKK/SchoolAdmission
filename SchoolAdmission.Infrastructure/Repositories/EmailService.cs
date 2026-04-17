using MimeKit;
using Microsoft.Extensions.Options;
using SchoolAdmission.Domain.Models;
using MailKit.Net.Smtp;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Infrastructure.Repositories;
public class EmailService(IOptions<EmailSettings> settings) : IEmailService
{
    private readonly EmailSettings _settings = settings.Value;

    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
        try
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(_settings.SenderName, _settings.SenderEmail!));
            email.To.Add(MailboxAddress.Parse(toEmail));
            email.Subject = subject;
            email.Body = new TextPart("html") { Text = body };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_settings.SmtpServer, _settings.Port, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_settings.Username, _settings.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
        catch (Exception ex)
        {
            // Log the exception (you can use a logging framework here)
            Console.WriteLine($"Error sending email: {ex.Message}");
        }
    }
}