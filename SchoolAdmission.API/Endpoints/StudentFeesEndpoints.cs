using MediatR;
using Microsoft.AspNetCore.Mvc;

public static class StudentFeesEndpoints
{
    public static void MapStudentFeesEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/student-fees")
                       .WithTags("Student Fees")
                       .RequireAuthorization();

        group.MapPost("/", async (
            [FromBody] SaveStudentFeesCommand command,
            IMediator mediator) =>
        {
            var result = await mediator.Send(command);
            return Results.Json(result, statusCode: result.StatusCode);
        });
    }
}
