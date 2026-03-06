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
        .WithDescription("Endpoints for managing standard master data");

        // GET ALL
        group.MapGet("/", async (IMediator mediator) =>
        {
            var result = await mediator.Send(new GetAllStandardMastersQuery());
            return Results.Ok(result);
        });

        // GET BY ID
        group.MapGet("/{id:int}", async (int id, IMediator mediator) =>
        {
            var result = await mediator.Send(new GetStandardMasterByIdQuery(id));

            return result is null
                ? Results.NotFound("Standard not found")
                : Results.Ok(result);
        });

        // CREATE
        group.MapPost("/", async ([FromBody] CreateStandardMasterCommand command, IMediator mediator) =>
        {
            var id = await mediator.Send(command);

            return Results.Ok(new
            {
                Success = true,
                Message = "Category created successfully",
                Data = id
            });
        });

        // UPDATE
        group.MapPut("/{id:int}", async (int id, [FromBody] UpdateStandardMasterCommand command, IMediator mediator) =>
        {
            command.StandardId = id;
            var success = await mediator.Send(command);

            if ((bool)success!)
            {
                return Results.Ok(new
                {
                    Success = true,
                    Message = "Standard updated successfully",
                    Data = id
                });
            }

            return Results.NotFound(new
            {
                Success = false,
                Message = "Standard not found",
                Data = (int?)null
            });
        });

        // DELETE
        group.MapDelete("/{id:int}", async (int id, IMediator mediator) =>
        {
            var success = await mediator.Send(new DeleteStandardMasterCommand(id));

            if (success)
            {
                return Results.Ok(new
                {
                    Success = true,
                    Message = "Standard deleted successfully",
                    Data = id
                });
            }

            return Results.NotFound(new
            {
                Success = false,
                Message = "Standard not found",
                Data = (int?)null
            });
        });
    }
}
