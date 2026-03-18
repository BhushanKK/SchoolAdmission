using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolAdmission.Domain;
using SchoolAdmission.Application.Features.Religions.Commands;
using SchoolAdmission.Application.Features.Religions.Queries;

namespace SchoolAdmission.API.Endpoints;

public static class ReligionMasterEndpoints
{
    public static void MapReligionMasterEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/religionmasters")
        .WithTags("Religion Master")
        .RequireAuthorization()
        .WithDescription("Endpoints for managing religion master data");

        // GET ALL
        group.MapGet("/", async (IMediator mediator) =>
        {
            var result = await mediator.Send(new GetAllReligionMastersQuery());
            return Results.Ok
            (
                ApiResponse<List<ReligionMaster>>
                .SuccessResponse
                (
                    result,
                    "Religion retrieved successfully"
                )
            );
        });

        // CREATE
        group.MapPost("/", async ([FromBody] CreateReligionMasterCommand command, IMediator mediator) =>
        {
            var id = await mediator.Send(command);

            return Results.Ok(new
            {
                Success = true,
                Message = "Religion created successfully",
                Data = id
            });
        });

        // GET BY ID
        group.MapGet("/{id:int}", async (int id, IMediator mediator) =>
        {
            var result = await mediator.Send(new GetReligionMasterByIdQuery(id));

            if (result is null)
                return Results.NotFound(ApiResponse<ReligionMaster>.FailureResponse("Religion not found"));

            return Results.Ok
            (
                ApiResponse<ReligionMaster>
                .SuccessResponse
                (
                    result, 
                    "Religion retrieved successfully"
                )
            );
        });

        // UPDATE
        group.MapPut("/{id:int}", async (int id, [FromBody] UpdateReligionMasterCommand command, IMediator mediator) =>
        {
            command.ReligionId = id;
            var success = await mediator.Send(command);

            if ((bool)success!)
            {
                return Results.Ok(new
                {
                    Success = true,
                    Message = "Religion updated successfully",
                    Data = id
                });
            }

            return Results.NotFound(new
            {
                Success = false,
                Message = "Religion not found",
                Data = (int?)null
            });
        });

        // DELETE
        group.MapDelete("/{id:int}", async (int id, IMediator mediator) =>
        {
            var success = await mediator.Send(new DeleteReligionMasterCommand(id));

            if (success)
            {
                return Results.Ok(new
                {
                    Success = true,
                    Message = "Religion deleted successfully",
                    Data = id
                });
            }

            return Results.NotFound(new
            {
                Success = false,
                Message = "Religion not found",
                Data = (int?)null
            });
        });
    }
}
