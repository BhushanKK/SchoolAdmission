using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace SchoolAdmission.API.Endpoints;

public static class StudentAddressEndpoints
{
    public static void MapStudentAddressEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/student-address")
                       .WithTags("Student Address")
                       .RequireAuthorization()
                       .WithDescription("Endpoints for managing Student Address data");

        group.MapPost("/", async (
            [FromBody] SaveStudentAddressesCommand command,
            IMediator mediator) =>
        {
            var studentId = await mediator.Send(command);

            return Results.Ok(new
            {
                Success = true,
                Message = "Student address saved successfully",
                Data = studentId
            });
        });

        group.MapPut("/{id:guid}", async (
            Guid id,
            [FromBody] SaveStudentAddressesCommand command,
            IMediator mediator) =>
        {
            command.StudentId = id;

            var result = await mediator.Send(command);

            return Results.Ok(new
            {
                Success = true,
                Message = "Student address updated successfully",
                Data = result
            });
        });
    }
}
