using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SchoolAdmission.API.Endpoints;

public static class StudentHealthEndpoints
{
    public static void MapStudentHealthEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/student-health")
                       .WithTags("Student Health")
                       .RequireAuthorization()
                       .WithDescription("Endpoints for managing Student Health data");

        group.MapPost("/", async (
            [FromBody] SaveStudentHealthCommand command,
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
            [FromBody] SaveStudentHealthCommand command,
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
