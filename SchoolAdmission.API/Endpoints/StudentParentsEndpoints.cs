using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SchoolAdmission.API.Endpoints;

public static class StudentParentEndpoints
{   
    public static void MapStudentParentEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/student-parent")
                       .WithTags("Student Parent")
                       .RequireAuthorization()
                       .WithDescription("Endpoints for managing Student Parent data");

        group.MapPost("/", async (
            [FromBody] SaveStudentParentCommand command,
            IMediator mediator) =>
        {
            var result = await mediator.Send(command);

            return Results.Ok(new
            {
                Success = true,
                Message = "Parent details saved successfully",
                Data = result
            });
        });

        group.MapPut("/{id:long}", async (long id,
            [FromBody] SaveStudentParentCommand command,
            IMediator mediator) =>
        {
            command.ParentId = id;
            var result = await mediator.Send(command);

            return Results.Ok(new
            {
                Success = true,
                Message = "Parent details updated successfully",
                Data = result
            });
        });
    }
}
