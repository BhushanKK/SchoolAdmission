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

            return Results.Ok(new
            {
                Success = true,
                Message = "Student fees saved successfully",
                Data = result
            });
        });

        group.MapPut("/{id:long}", async (long id,
            [FromBody] SaveStudentFeesCommand command,
            IMediator mediator) =>
        {
            command.FeeId = id;

            var result = await mediator.Send(command);

            return Results.Ok(new
            {
                Success = true,
                Message = "Student fees updated successfully",
                Data = result
            });
        });
    }
}
