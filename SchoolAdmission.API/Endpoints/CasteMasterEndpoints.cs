using MediatR;
using Microsoft.AspNetCore.Mvc;

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

            return (bool)success! 
                ? Results.Ok(ApiResponse<object>.SuccessResponse(null, "Caste updated successfully"))
                : Results.NotFound(ApiResponse<object>.FailureResponse("Caste not found"));

        });

        // Delete
        group.MapDelete("/{id:int}", static async (int id, IMediator mediator) =>
        {
            var success = await mediator.Send(new DeleteCasteMasterCommand(id));

            return success

                ? Results.Ok(ApiResponse<object>.SuccessResponse(null, "Caste deleted successfully"))
                : Results.NotFound(ApiResponse<object>.FailureResponse("Caste not found"));

                
        });
    }

    private class GetAllCasteMastersQuery : IRequest<List<CasteMasterQueryDto>?>
    {
    }

    private class GetCasteMasterByIdQuery : IRequest<CasteMasterQueryDto?>
    {
        private int id;

        public GetCasteMasterByIdQuery(int id)
        {
            this.id = id;
        }
    }

    private class CreateCasteMasterCommand
    {
    }

    private class UpdateCasteMasterCommand
    {
        public int CasteId { get; internal set; }
    }
}

internal class DeleteCasteMasterCommand : IRequest<bool>
{
    private int id;

    public DeleteCasteMasterCommand(int id)
    {
        this.id = id;
    }
}