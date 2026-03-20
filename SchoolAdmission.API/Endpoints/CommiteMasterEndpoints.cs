using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolAdmission.Application.Features.CommiteMasters.Commands;
using SchoolAdmission.Application.Features.CommiteMasters.Queries;
using SchoolAdmission.Domain;

namespace SchoolAdmission.API.Endpoints;

public static class CommiteMasterEndpoints
{
    public static void MapCommiteMasterEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/CommiteMasters")
            .WithTags("Commite Master")
            .RequireAuthorization()
            .WithDescription("Endpoints for managing Commite master data");

        // GET ALL
        group.MapGet("/", async (IMediator mediator) =>
        {
            var result = await mediator.Send(new GetAllCommiteMastersQuery());
            return Results.Ok
            (
                ApiResponse<List<CommiteMaster>>
                .SuccessResponse
                (
                    result, 
                    "Commite retrieved successfully"
                )
            );
        });

        // CREATE
        group.MapPost("/", async ([FromBody] CreateCommiteMasterCommand command, IMediator mediator) =>
        {
            var id = await mediator.Send(command);

            return Results.Ok(new
            {
                Success = true,
                Message = "Commite created successfully",
                Data = id
            });
        });

        // GET BY ID
        group.MapGet("/{id:int}", async (int id, IMediator mediator) =>
        {
            var result = await mediator.Send(new GetCommiteMasterByIdQuery(id));

            return result is null
                ? Results.NotFound("Commite not found")
                : Results.Ok
                (
                    ApiResponse<CommiteMaster>
                    .SuccessResponse
                    (
                        result, 
                        "Commite retrieved successfully"
                    )             
                );
        });

        // UPDATE By Id
        group.MapPut("/{id:int}", async (int id, [FromBody] UpdateCommiteMasterCommand command, IMediator mediator) =>
        {
            command.CommiteeId = id;
            var success = await mediator.Send(command);

            return success
                ? Results.Ok("Commite updated successfully")
                : Results.NotFound("Commite not found");
        });

        // DELETE By Id
        group.MapDelete("/{id:int}", async (int id, IMediator mediator) =>
        {
            var success = await mediator.Send(new DeleteCommiteMasterCommand(id));

            return success
                ? Results.Ok("Commite deleted successfully")
                : Results.NotFound("Commite not found");
        });
    }
}