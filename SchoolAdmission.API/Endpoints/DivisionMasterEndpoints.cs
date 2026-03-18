using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolAdmission.Application.Features.DivisionMasters.Commands;
using SchoolAdmission.Application.Features.DivisionMasters.Queries;
using SchoolAdmission.Domain;

namespace SchoolAdmission.API.Endpoints;

public static class DivisionMasterEndpoints
{
    public static void MapDivisionMasterEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/Divisionmasters")
        .WithTags("Division Master")
        .RequireAuthorization()
        .WithDescription("Endpoints for managing Division master data");

        // GET ALL
        group.MapGet("/", async (IMediator mediator) =>
        {
            var result = await mediator.Send(new GetAllDivisionMastersQuery());
            return Results.Ok
            (
                ApiResponse<List<DivisionMaster>>
                .SuccessResponse
                (
                    result, 
                    "Division retrieved successfully"
                )
            );
        });

    
        // CREATE
        group.MapPost("/", async ([FromBody] CreateDivisionMasterCommand command, IMediator mediator) =>
        {
            var id = await mediator.Send(command);

            return Results.Ok(new
            {
                Success = true,
                Message = "Division created successfully",
                Data = id
            });
        });

        // GET BY ID
        group.MapGet("/{id:int}", async (int id, IMediator mediator) =>
        {
            var result = await mediator.Send(new GetDivisionMasterByIdQuery(id));

            return result is null
                ? Results.NotFound("Division not found")
                : Results.Ok
                (
                    ApiResponse<DivisionMaster>
                    .SuccessResponse
                    (
                        result, 
                        "Division retrieved successfully"
                    )
                );
        });

        // UPDATE
        group.MapPut("/{id:int}", async (int id, [FromBody] UpdateDivisionMasterCommand command, IMediator mediator) =>
        {
            command.DivisionId = id;
            var success = await mediator.Send(command);

            return (bool)success!
                ? Results.Ok("Division updated successfully")
                : Results.NotFound("Division not found");
        });

        // DELETE
        group.MapDelete("/{id:int}", async (int id, IMediator mediator) =>
        {
            var success = await mediator.Send(new DeleteDivisionMasterCommand(id));

            return success
                ? Results.Ok("Division deleted successfully")
                : Results.NotFound("Division not found");
        });
    }
}
