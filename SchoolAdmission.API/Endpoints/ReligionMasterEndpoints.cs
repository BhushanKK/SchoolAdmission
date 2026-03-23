using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolAdmission.Application.Features.ReligionMasters.Commands;
using SchoolAdmission.Application.Features.ReligionMasters.Queries;

namespace SchoolAdmission.API.Endpoints;

public static class ReligionMasterEndpoints
{
    public static void MapReligionMasterEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/religionmasters")
                       .WithTags("Religion Master")
                       .RequireAuthorization()
                       .WithDescription("Endpoints for managing Religion master data");

        // GET ALL
        group.MapGet("/", async (IMediator mediator) =>
        {
            var response = await mediator.Send(new GetAllReligionMastersQuery());
            return Results.Json(response, statusCode: response.StatusCode);
        });

        // GET BY ID
        group.MapGet("/{id:int}", async (int id, IMediator mediator) =>
        {
            var response = await mediator.Send(new GetReligionMasterByIdQuery(id));
            return Results.Json(response, statusCode: response.StatusCode);
        });

        // CREATE
        group.MapPost("/", async ([FromBody] CreateReligionMasterCommand command, IMediator mediator) =>
        {
            var response = await mediator.Send(command);
            return Results.Json(response, statusCode: response.StatusCode);
        });

        // UPDATE
        group.MapPut("/{id:int}", async (int id,
            [FromBody] UpdateReligionMasterCommand command, IMediator mediator) =>
        {
            command.ReligionId = id;
            var response = await mediator.Send(command);
            return Results.Json(response, statusCode: response.StatusCode);
        });

        // DELETE
        group.MapDelete("/{id:int}", async (int id, IMediator mediator) =>
        {
            var response = await mediator.Send(new DeleteReligionMasterCommand(id));
            return Results.Json(response, statusCode: response.StatusCode);
        });
    }
}