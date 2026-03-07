using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SchoolAdmission.API.Endpoints;

public static class BranchMasterEndpoints
{
    public static void MapBranchMasterEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/Branchmasters")
        .WithTags("Branch Master")
        .WithDescription("Endpoints for managing Branch master data");

        // GET ALL
        group.MapGet("/", async (IMediator mediator) =>
        {
            var result = await mediator.Send(new GetAllBranchMastersQuery());
            return Results.Ok(result);
        });

        // GET BY ID
        group.MapGet("/{id:int}", async (int id, IMediator mediator) =>
        {
            var result = await mediator.Send(new GetBranchMasterByIdQuery(id));

            return result is null
                ? Results.NotFound("Branch not found")
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
                ? Results.Ok("Branch updated successfully")
                : Results.NotFound("Branch not found");
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

    private class CreateBranchMasterCommand
    {
    }

    private class GetAllBranchMastersQuery : IRequest<object?>
    {
    }
}

internal class DeleteBranchMasterCommand : IRequest<bool>
{
    private int id;

    public DeleteBranchMasterCommand(int id)
    {
        this.id = id;
    }
}

internal class UpdateBranchMasterCommand
{
    public int BranchId { get; internal set; }
}

internal class GetBranchMasterByIdQuery : IRequest<object?>
{
    private int id;

    public GetBranchMasterByIdQuery(int id)
    {
        this.id = id;
    }
}