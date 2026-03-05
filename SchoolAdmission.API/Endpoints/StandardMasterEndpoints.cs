using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolAdmission.Application.Features.StandardMasters.Commands;
using SchoolAdmission.Application.Features.StandardMasters.Queries;

namespace SchoolAdmission.API.Endpoints;

public static class StandardMasterEndpoints
{
    public static void MapStandardMasterEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/standardmaster");

        // Get All
        group.MapGet("/", async (IMediator mediator) =>
        {
            var result = await mediator.Send(new GetAllStandardMastersQuery());
            return Results.Ok(result);
        });

        // Get By Id
        group.MapGet("/{id:int}", async (int id, IMediator mediator) =>
        {
            var result = await mediator.Send(new GetStandardMasterByIdQuery(id));

            if (result == null)
                return Results.NotFound(new { Message = "Standard not found" });

            return Results.Ok(result);
        });

        // Create
        group.MapPost("/", async (CreateStandardMasterCommand command, IMediator mediator) =>
        {
            var id = await mediator.Send(command);
            return Results.Created($"/api/standardmaster/{id}", id);
        });

        // Update
        group.MapPut("/{id:int}", async (int id, UpdateStandardMasterCommand command, IMediator mediator) =>
        {
            if (id != command.Id)
                return Results.BadRequest(new { Message = "Id mismatch" });

            var success = await mediator.Send(command);

            if (!success)
                return Results.NotFound(new { Message = "Standard not found" });

            return Results.NoContent();
        });

        // Delete
        group.MapDelete("/{id:int}", async (int id, IMediator mediator) =>
        {
            var success = await mediator.Send(new DeleteStandardMasterCommand(id));

            if (!success)
                return Results.NotFound(new { Message = "Standard not found" });

            return Results.NoContent();
        });
    }
}