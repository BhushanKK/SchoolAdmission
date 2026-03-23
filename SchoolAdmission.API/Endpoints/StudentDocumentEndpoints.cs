using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SchoolAdmission.API.Endpoints;

public static class StudentDocumentEndpoints
{
    public static void MapStudentDocumentEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/student-document")
                       .WithTags("Student Document")
                       .RequireAuthorization()
                       .WithDescription("Endpoints for managing Student Document data");

        group.MapPost("/", async (
            [FromBody] SaveStudentDocumentCommand command,
            IMediator mediator) =>
        {
            var result = await mediator.Send(command);

            return Results.Ok(new
            {
                Success = true,
                Message = "Student document saved successfully",
                Data = result
            });
        });

        group.MapPut("/{id:long}", async (long id,
            [FromBody] SaveStudentDocumentCommand command,
            IMediator mediator) =>
        {
            command.DocumentId = id;

            var result = await mediator.Send(command);

            return Results.Ok(new
            {
                Success = true,
                Message = "Student document updated successfully",
                Data = result
            });
        });
    }
}