using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolAdmission.Application.Features.CommiteMasters.Commands;
using SchoolAdmission.Application.Features.CommiteMasters.Queries;

namespace SchoolAdmission.API.Endpoints;

public static class CommiteMasterEndpoints
{
    public static void MapCommiteMasterEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/CommiteMasters")
            .WithTags("Commite Master")
            .RequireAuthorization()
            .WithDescription("Endpoints for managing Commite master data");

        // GET ALL
        group.MapGet("/", async (IMediator mediator) =>
        {
            var response = await mediator.Send(new GetAllCommiteMastersQuery());
            return Results.Json(response, statusCode: response.StatusCode);
        });

        // GET BY ID
        group.MapGet("/{id:int}", async (int id, IMediator mediator) =>
        {
            var response = await mediator.Send(new GetCommiteMasterByIdQuery(id));
            return Results.Json(response, statusCode: response.StatusCode);
        });

        // CREATE
        group.MapPost("/", async ([FromBody] CreateCommiteMasterCommand command, IMediator mediator) =>
        {
            var response = await mediator.Send(command);
            return Results.Json(response, statusCode: response.StatusCode);
        });

        // UPDATE
        group.MapPut("/{id:int}", async (int id, [FromBody] UpdateCommiteMasterCommand command, IMediator mediator) =>
        {
            command.CommiteeId = id;
            var response = await mediator.Send(command);
            return Results.Json(response, statusCode: response.StatusCode);
        });

        // DELETE
        group.MapDelete("/{id:int}", async (int id, IMediator mediator) =>
        {
            var response = await mediator.Send(new DeleteCommiteMasterCommand(id));
            return Results.Json(response, statusCode: response.StatusCode);
        });
    }
}