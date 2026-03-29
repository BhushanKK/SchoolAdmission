using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolAdmission.Application.Features.StudentDetails.Commands;
using SchoolAdmission.Application.Features.StudentDetails.Queries;

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
            var result = await mediator.Send(command);

            return Results.Json(result, statusCode: result.StatusCode);
        });

        group.MapPut("/{id:guid}", async (Guid id,
            [FromBody] UpdateStudentCommand command,
            IMediator mediator) =>
        {
            command.StudentId = id;
            var result = await mediator.Send(command);
            return Results.Json(result, statusCode: result.StatusCode);
        });
    }
}
