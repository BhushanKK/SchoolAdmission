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

        // ✅ Create / Save using SP
        group.MapPost("/", async (
            [FromBody] SaveStudentAcademicHistoryCommand command,
            IMediator mediator) =>
        {
            var result = await mediator.Send(command);

            return Results.Ok(new
            {
                Success = true,
                Message = "Student academic history saved successfully",
                Data = result
            });
        });

        // ✅ Update using SP
        group.MapPut("/{id:long}", async (
            long id,
            [FromBody] SaveStudentAcademicHistoryCommand command,
            IMediator mediator) =>
        {
            command.AcademicHistoryId = id;

            var result = await mediator.Send(command);

            return Results.Ok(new
            {
                Success = true,
                Message = "Student academic history updated successfully",
                Data = result
            });
        });
    }
}