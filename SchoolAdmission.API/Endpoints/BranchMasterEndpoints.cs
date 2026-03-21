using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolAdmission.Application.Features.BranchMasters.Commands;
using SchoolAdmission.Application.Features.BranchMasters.Queries;

namespace SchoolAdmission.API.Endpoints;

public static class BranchMasterEndpoints
{
    public static void MapBranchMasterEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/Branchmasters")
        .WithTags("Branch Master")
        .RequireAuthorization()
        .WithDescription("Endpoints for managing Branch master data");

        // GET ALL
        group.MapGet("/", async (IMediator mediator) =>
        {
            var result = await mediator.Send(new GetAllBranchMasterQuery());
            return Results.Ok(result);
        });

        // GET BY ID
        group.MapGet("/{id:int}", async (int id, IMediator mediator) =>
        {
            var result = await mediator.Send(new GetBranchMasterByIdQuery(id));

            return result is null
                ? Results.NotFound("BranchName not found")
                : Results.Ok(result);
        });

        // CREATE
        group.MapPost("/", async ([FromBody] CreateBranchMasterCommand command, IMediator mediator) =>
        {
            var id = await mediator.Send(command);

            return Results.Ok(new
            {
                Success = true,
                Message = "Branch created successfully",
                Data = id
            });
        });

        // UPDATE
        group.MapPut("/{id:int}", async (int id, [FromBody] UpdateBranchMasterCommand command, IMediator mediator) =>
        {
            command.BranchId = id;
            var success = await mediator.Send(command);

            return (bool)success!
                ? Results.Ok("Branch Id updated successfully")
                : Results.NotFound("Branch Id not found");
        });

        // DELETE
        group.MapDelete("/{id:int}", async (int id, IMediator mediator) =>
        {
            var success = await mediator.Send(new DeleteBranchMasterCommand(id));

            return success
                ? Results.Ok("Branch deleted successfully")
                : Results.NotFound("Branch not found");
        });
    }
}
