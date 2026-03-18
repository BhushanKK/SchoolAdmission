using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolAdmission.Application.Features.StudentDetails.Commands;

namespace SchoolAdmission.API.Endpoints;

public static class StudentSignupEndpoints
{
    public static void MapStudentSignupEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/student-signup")
            .WithTags("Student Signup")
            .RequireAuthorization()
            .WithDescription("Endpoints for student registration");

        group.MapPost("/", async (
            [FromBody] CreateStudentSignUpCommand command,
            IMediator mediator) =>
        {
            var studentId = await mediator.Send(command);

            return Results.Ok(new
            {
                Success = true,
                Message = "Student registered successfully",
                Data = studentId
            });
        });
    }
}