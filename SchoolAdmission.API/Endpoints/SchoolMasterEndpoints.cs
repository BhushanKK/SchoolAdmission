using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolAdmission.Application.Features.SchoolMasters.Commands;
using SchoolAdmission.Application.Features.SchoolMasters.Queries;

namespace SchoolAdmission.API.Endpoints;

public static class SchoolMasterEndpoints
{
    public static void MapSchoolMasterEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/schoolmasters")
                       .WithTags("School Master")
                       .RequireAuthorization()
                       .WithDescription("Endpoints for managing School master data");

        // GET ALL
        group.MapGet("/", async (IMediator mediator) =>
        {
            var response = await mediator.Send(new GetAllSchoolMasterQuery());
            return Results.Json(response, statusCode: response.StatusCode);
        });

        // GET BY ID
        group.MapGet("/{id:int}", async (int id, IMediator mediator) =>
        {
            var response = await mediator.Send(new GetSchoolMasterByIdQuery(id));
            return Results.Json(response, statusCode: response.StatusCode);
        });

        // CREATE
        group.MapPost("/", async ([FromBody] CreateSchoolMasterCommand command, IMediator mediator) =>
        {
            var response = await mediator.Send(command);
            return Results.Json(response, statusCode: response.StatusCode);
        });

        // UPDATE
        group.MapPut("/{id:int}", async (int id,
            [FromBody] UpdateSchoolMasterCommand command, IMediator mediator) =>
        {
            command.SchoolId = id;
            var response = await mediator.Send(command);
            return Results.Json(response, statusCode: response.StatusCode);
        });

        // DELETE
        group.MapDelete("/{id:int}", async (int id, IMediator mediator) =>
        {
            var response = await mediator.Send(new DeleteSchoolMasterCommand(id));
            return Results.Json(response, statusCode: response.StatusCode);
        });
    }
}