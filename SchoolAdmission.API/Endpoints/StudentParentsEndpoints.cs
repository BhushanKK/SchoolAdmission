using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolAdmission.Application.Features.StudentParents.Commands;
using SchoolAdmission.Application.Features.StudentParents.Queries;

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
        
        group.MapGet("/{studentId:guid}", async (Guid studentId, IMediator mediator) =>
        {
            var response = await mediator.Send(new GetStudentParentsByStudentIdQuery(studentId));
            return Results.Json(response, statusCode: response.StatusCode);
        });
    }
}
