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
            var response = await mediator.Send(command);
            return Results.Json(response, statusCode: response.StatusCode);
        });
    }
}
