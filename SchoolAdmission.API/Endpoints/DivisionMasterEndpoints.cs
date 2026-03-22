using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolAdmission.Application.Features.DivisionMasters.Commands;
using SchoolAdmission.Application.Features.DivisionMasters.Queries;

namespace SchoolAdmission.API.Endpoints;

public static class DivisionMasterEndpoints
{
    public static void MapDivisionMasterEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/divisionmasters")
                       .WithTags("Division Master")
                       .RequireAuthorization()
                       .WithDescription("Endpoints for managing Division master data");

        // GET ALL
        group.MapGet("/", async (IMediator mediator) =>
        {
            var response = await mediator.Send(new GetAllDivisionMastersQuery());
            return Results.Json(response, statusCode: response.StatusCode);
        });

        // GET BY ID
        group.MapGet("/{id:int}", async (int id, IMediator mediator) =>
        {
            var response = await mediator.Send(new GetDivisionMasterByIdQuery(id));
            return Results.Json(response, statusCode: response.StatusCode);
        });

        // CREATE
        group.MapPost("/", async ([FromBody] CreateDivisionMasterCommand command, IMediator mediator) =>
        {
            var response = await mediator.Send(command);
            return Results.Json(response, statusCode: response.StatusCode);
        });

        // UPDATE
        group.MapPut("/{id:int}", async (int id,
            [FromBody] UpdateDivisionMasterCommand command, IMediator mediator) =>
        {
            command.DivisionId = id;
            var response = await mediator.Send(command);
            return Results.Json(response, statusCode: response.StatusCode);
        });

        // DELETE
        group.MapDelete("/{id:int}", async (int id, IMediator mediator) =>
        {
            var response = await mediator.Send(new DeleteDivisionMasterCommand(id));
            return Results.Json(response, statusCode: response.StatusCode);
        });
    }
}