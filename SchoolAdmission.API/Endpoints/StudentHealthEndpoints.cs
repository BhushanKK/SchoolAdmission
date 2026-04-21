using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolAdmission.Application.Features.StudentHealth.Commands;
using SchoolAdmission.Application.Features.StudentHealth.Queries;

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
        group.MapGet("/{studentId:guid}", async (Guid studentId, IMediator mediator) =>
        {
            var response = await mediator.Send(new GetStudentHealthByStudentIdQuery(studentId));
            return Results.Json(response, statusCode: response.StatusCode);
        });
    }
}
