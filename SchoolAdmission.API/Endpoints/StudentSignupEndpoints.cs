using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolAdmission.Application.Features.StudentDetails.Commands;

namespace SchoolAdmission.API.Endpoints;

public static class StudentSignupEndpoints
{
    public static void MapStudentSignupEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/student")
            .WithTags("Student Details")
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

        group.MapPut("/{id:guid}", async (Guid id,
            [FromBody] UpdateStudentCommand command,
            IMediator mediator) =>
        {
            command.StudentId = id;
            var result = await mediator.Send(command);

            return Results.Ok(new
            {
                Success = true,
                Message = "Student details updated successfully",
                Data = result
            });
        });
    }
}