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
            var response = await mediator.Send(command);
            return Results.Json(response, statusCode: response.StatusCode);
        });
    }
}
