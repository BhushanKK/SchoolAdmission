using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolAdmission.Application.Features.FeesStructureDetails.Commands;
using SchoolAdmission.Application.Features.FeesStructureDetails.Queries;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.API.Endpoints;

public static class FeesStructureEndpoints
{
    public static void MapFeesStructureEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/feesstructures")
        .WithTags("Fees Structure")
        .WithDescription("Endpoints for managing fees structure data");

        // GET ALL
        group.MapGet("/", async (IMediator mediator) =>
        {
            var result = await mediator.Send(new GetAllFeesStructureDetailsQuery());
            return Results.Ok(ApiResponse<List<FeesStructureQueryDto>>.SuccessResponse(result, "Fees structure retrieved successfully"));
        });

        // GET BY ID
        group.MapGet("/{id:int}", async (int id, IMediator mediator) =>
        {
            var result = await mediator.Send(new GetFeesStructureByIdQuery(id));

            if (result is null)
                return Results.NotFound(ApiResponse<FeesStructureQueryDto>.FailureResponse("Fees structure not found"));

            return Results.Ok(ApiResponse<FeesStructureQueryDto>.SuccessResponse(result, "Fees structure retrieved successfully"));
        });

        // CREATE
        group.MapPost("/", async ([FromBody] CreateFeesStructureCommand command, IMediator mediator) =>
        {
            var id = await mediator.Send(command);

            return Results.Ok(new
            {
                Success = true,
                Message = "Fees structure created successfully",
                Data = id
            });
        });

        // UPDATE
        group.MapPut("/{id:int}", async (int id, [FromBody] UpdateFeesStructureCommand command, IMediator mediator) =>
        {
            command.FeeId = id;
            var success = await mediator.Send(command);

            if ((bool)success!)
            {
                return Results.Ok(new
                {
                    Success = true,
                    Message = "Fee updated successfully",
                    Data = id
                });
            }

            return Results.NotFound(new
            {
                Success = false,
                Message = "Fees not found",
                Data = (int?)null
            });
        });

        // DELETE
        group.MapDelete("/{id:int}", async (int id, IMediator mediator) =>
        {
            var success = await mediator.Send(new DeleteFeesStructureCommand(id));

            if (success)
            {
                return Results.Ok(new
                {
                    Success = true,
                    Message = "Fee Head deleted successfully",
                    Data = id
                });
            }

            return Results.NotFound(new
            {
                Success = false,
                Message = "Fee Head not found",
                Data = (int?)null
            });
        });
    }
}
