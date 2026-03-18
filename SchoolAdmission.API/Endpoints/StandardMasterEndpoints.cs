using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolAdmission.Application.Features.StandardMasters.Commands;
using SchoolAdmission.Application.Features.StandardMasters.Queries;
using SchoolAdmission.Domain;

namespace SchoolAdmission.API.Endpoints;

public static class StandardMasterEndpoints
{
    public static void MapStandardMasterEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/standardmasters")
        .WithTags("Standard Master")
        .RequireAuthorization()
        .WithDescription("Endpoints for managing standard master data");

        // GET ALL
        group.MapGet("/", async (IMediator mediator) =>
        {
            var result = await mediator.Send(new GetAllStandardMastersQuery());

            return Results.Ok
            (
                ApiResponse<List<StandardMaster>>
                .SuccessResponse
                (
                    result, 
                    "Standard retrieved successfully"
                )
            );       
        });

        // CREATE
        group.MapPost("/", async ([FromBody] CreateStandardMasterCommand command, IMediator mediator) =>
        {
            var id = await mediator.Send(command);

            return Results.Ok(new
            {
                Success = true,
                Message = "Standard created successfully",
                Data = id
            });
        });

         // GET BY ID
        group.MapGet("/{id:int}", async (int id, IMediator mediator) =>
        {
            var result = await mediator.Send(new GetStandardMasterByIdQuery(id));
            return result is null
                ? Results.NotFound("Standard not found")
                : Results.Ok
                (
                    ApiResponse<StandardMaster>
                    .SuccessResponse
                    (
                        result, 
                        "Standard retrieved successfully"
                    )
                );
        });

        // UPDATE
        group.MapPut("/{id:int}", async (int id, [FromBody] UpdateStandardMasterCommand command, IMediator mediator) =>
        {
            command.StandardId = id;
            var success = await mediator.Send(command);

            return (bool)success!
                ? Results.Ok("Standard updated successfully")
                : Results.NotFound("Standard not found");

        });

        // DELETE
        group.MapDelete("/{id:int}", async (int id, IMediator mediator) =>
        {
            var success = await mediator.Send(new DeleteStandardMasterCommand(id));
            return success
                ? Results.Ok("Standard deleted successfully")
                : Results.NotFound("Standard not found");

        });
    }
}
