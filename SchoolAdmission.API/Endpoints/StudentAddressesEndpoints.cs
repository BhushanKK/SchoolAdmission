using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolAdmission.Application.Features.StudentAddress.Queries;
using SchoolAdmission.Application.Features.StudentAddresses.Commands;
namespace SchoolAdmission.API.Endpoints;

public static class StudentAddressEndpoints
{
    public static void MapStudentAddressEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/student-address")
                       .WithTags("Student Address")
                       .RequireAuthorization()
                       .WithDescription("Endpoints for managing Student Address data");

        group.MapPost("/", async (
            [FromBody] SaveStudentAddressesCommand command,
            IMediator mediator) =>
        {
            var response = await mediator.Send(command);
            return Results.Json(response, statusCode: response.StatusCode);
        });

        group.MapGet("/{studentId:guid}", async (Guid studentId, IMediator mediator) =>
        {
            var response = await mediator.Send(new GetStudentAddressByStudentIdQuery(studentId));
            return Results.Json(response, statusCode: response.StatusCode);
        });
    }
}
