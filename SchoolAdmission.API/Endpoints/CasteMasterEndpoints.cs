using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolAdmission.Application.Features.CasteMasters.Commands;
using SchoolAdmission.Application.Features.CasteMasters.Queries;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.API.Endpoints;

public static class CasteMasterEndpoints
{
    public static void MapCasteMasterEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/castemaster")
        .WithTags("Caste Master")
        .WithDescription("Endpoints for managing caste master data");

        // Lookup endpoint (for dropdowns, etc.)
        group.MapGet("/", async (IMediator mediator) =>
        {
            var result = await mediator.Send(new GetAllCasteMastersQuery());
            return Results.Ok(ApiResponse<List<CasteMasterQueryDto>>.SuccessResponse(result, "Caste retrieved successfully"));
        });

        // Get by Id
        group.MapGet("/{id:int}", async (int id, IMediator mediator) =>
        {
            var result = await mediator.Send(new GetCasteMasterByIdQuery(id));

            return result is null
                ? Results.NotFound(ApiResponse<CasteMasterQueryDto>.FailureResponse("Caste not found"))
                : Results.Ok(ApiResponse<CasteMasterQueryDto>.SuccessResponse(result, "Caste retrieved successfully"));
        });

        // Create
        group.MapPost("/", async ([FromBody] CreateCasteMasterCommand command, IMediator mediator) =>
        {
            var id = await mediator.Send(command);
            return Results.Ok(new
            {
                success = true,
                message = "Caste created successfully",
                data = id
            });
        });

        // Update
        group.MapPut("/{id:int}", async (int id, [FromBody] UpdateCasteMasterCommand command, IMediator mediator) =>
        {

            command.CasteId = id; // Ensure the ID from the route is used
            var success = await mediator.Send(command);

            return success
                ? Results.Ok(ApiResponse<object>.SuccessResponse(null, "Caste updated successfully"))
                : Results.NotFound(ApiResponse<object>.FailureResponse("Caste not found"));

            command.CasteId = id;
            var success = await mediator.Send(command);

            if ((bool)success!)
            {
                return Results.Ok(new
                {
                    Success = true,
                    Message = "Caste updated successfully",
                    Data = id
                });
            }

            return Results.NotFound(new
            {
                Success = false,
                Message = "Caste not found",
                Data = (int?)null
            });

        });

        // Delete
        group.MapDelete("/{id:int}", async (int id, IMediator mediator) =>
        {
            var success = await mediator.Send(new DeleteCasteMasterCommand(id));

            return success

                ? Results.Ok(ApiResponse<object>.SuccessResponse(null, "Caste deleted successfully"))
                : Results.NotFound(ApiResponse<object>.FailureResponse("Caste not found"));

                ? Results.Ok(new
                {
                    Success = true,
                    Message = "Caste deleted successfully",
                    Data = id
                })
                : Results.NotFound(new
                {
                    Success = false,
                    Message = "Caste not found",
                    Data = (int?)null
                });

        });
    }
}