using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SchoolAdmission.API.Endpoints;

public static class StudentAcademicHistoryEndpoints
{
    public static void MapStudentAcademicHistoryEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/student-academic-history")
                       .WithTags("Student Academic History")
                       .RequireAuthorization()
                       .WithDescription("Endpoints for managing Student Academic History data");

        group.MapPost("/", async (
            [FromBody] SaveStudentAcademicHistoryCommand command,
            IMediator mediator) =>
        {
            var result = await mediator.Send(command);
            return Results.Json(result, statusCode: result.StatusCode);
        });
    }
}
