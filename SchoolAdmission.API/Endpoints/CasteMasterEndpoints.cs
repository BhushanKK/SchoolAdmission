using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolAdmission.Application.Features.CasteMasters.Commands;
using SchoolAdmission.Application.Features.CasteMasters.Queries;
using SchoolAdmission.Domain;

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
            var result = await mediator.Send(new GetAllCasteMasterQuery());
            return result is null ?
            Results.NotFound(ApiResponse<CasteMaster>.FailureResponse("Caste not found")) :
            Results.Ok
                (
                    ApiResponse<List<CasteMaster>>
                    .SuccessResponse
                    (
                        result, 
                        "Caste retrieved successfully"
                    )
                );
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

        // Get by Id
        group.MapGet("/{id:int}", async (int id, IMediator mediator) =>
        {
            var result = await mediator.Send(new GetCasteMasterByIdQuery(id));

            return result is null
                ? Results.NotFound(ApiResponse<CasteMaster>.FailureResponse("Caste not found"))
                : Results.Ok
                (
                    ApiResponse<CasteMaster>
                    .SuccessResponse
                    (
                        result, 
                        "Caste retrieved successfully"
                    )
                );
        });

        // Update
        group.MapPut("/{id:int}", async (int id, [FromBody] UpdateCasteMasterCommand command, IMediator mediator) =>
        {

            command.CasteId = id; // Ensure the ID from the route is used
            var success = await mediator.Send(command);

            return (bool)success! 
                ? Results.Ok(ApiResponse<object>.SuccessResponse(true, $"Caste updated successfully with id: {id}"))
                : Results.NotFound(ApiResponse<object>.FailureResponse("Caste not found"));

        });

        // Delete
        group.MapDelete("/{id:int}", static async (int id, IMediator mediator) =>
        {
            var success = await mediator.Send(new DeleteCasteMasterCommand(id));

            return success

                ? Results.Ok(ApiResponse<object>.SuccessResponse(null, $"Caste deleted successfully with id: {id}"))
                : Results.NotFound(ApiResponse<object>.FailureResponse("Caste not found"));
        });
    }  
}

