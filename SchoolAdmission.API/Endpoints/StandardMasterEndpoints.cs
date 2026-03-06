using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolAdmission.Application.Features.StandardMasters.Commands;
using SchoolAdmission.Application.Features.StandardMasters.Queries;


using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Dtos;


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

            return Results.Ok(ApiResponse<List<StandardMaster>>.SuccessResponse(result, "Standard retrieved successfully"));

        });

        // GET BY ID
        group.MapGet("/{id:int}", async (int id, IMediator mediator) =>
        {
            var result = await mediator.Send(new GetStandardMasterByIdQuery(id));
            return result is null
                ? Results.NotFound("Standard not found")
                : Results.Ok(result);

            if (result is null)
                return Results.NotFound(ApiResponse<StandardMasterQueryDto>.FailureResponse("Standard not found"));

            return Results.Ok(ApiResponse<StandardMasterQueryDto>.SuccessResponse(result, "Standard retrieved successfully"));

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

        // UPDATE
        group.MapPut("/{id:int}", async (int id, [FromBody] UpdateStandardMasterCommand command, IMediator mediator) =>
        {
            command.StandardId = id;
            var success = await mediator.Send(command);


            return (bool)success!
                ? Results.Ok("Standard updated successfully")
                : Results.NotFound("Standard not found");

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
            return success
                ? Results.Ok("Standard deleted successfully")
                : Results.NotFound("Standard not found");

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
