using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolAdmission.Application.Features.StandardMasters.Commands;
using SchoolAdmission.Application.Features.StandardMasters.Queries;

namespace SchoolAdmission.API.Endpoints;

public static class StandardMasterEndpoints
{
    public static void MapStandardMasterEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/standardmasters")
                       .WithTags("Standard Master")
                       .RequireAuthorization()
                       .WithDescription("Endpoints for managing Standard master data");

        // GET ALL
        group.MapGet("/", async (IMediator mediator) =>
        {
            var response = await mediator.Send(new GetAllStandardMasterQuery());
            return Results.Json(response, statusCode: response.StatusCode);
        });

        // GET BY ID
        group.MapGet("/{id:int}", async (int id, IMediator mediator) =>
        {
            var response = await mediator.Send(new GetStandardMasterByIdQuery(id));
            return Results.Json(response, statusCode: response.StatusCode);
        });

        // CREATE
        group.MapPost("/", async ([FromBody] CreateStandardMasterCommand command, IMediator mediator) =>
        {
            var response = await mediator.Send(command);
            return Results.Json(response, statusCode: response.StatusCode);
        });

        // UPDATE
        group.MapPut("/{id:int}", async (int id,
            [FromBody] UpdateStandardMasterCommand command, IMediator mediator) =>
        {
            command.StandardId = id;
            var response = await mediator.Send(command);
            return Results.Json(response, statusCode: response.StatusCode);
        });

        // DELETE
        group.MapDelete("/{id:int}", async (int id, IMediator mediator) =>
        {
            var response = await mediator.Send(new DeleteStandardMasterCommand(id));
            return Results.Json(response, statusCode: response.StatusCode);
        });
    }
}