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
            var response = await mediator.Send(new GetAllBranchMasterQuery());
            return Results.Json(response, statusCode: response.StatusCode);
        });

        // GET BY ID
        group.MapGet("/{id:int}", async (int id, IMediator mediator) =>
        {
            var response = await mediator.Send(new GetBranchMasterByIdQuery(id));
            return Results.Json(response, statusCode: response.StatusCode);
        });

        // CREATE
        group.MapPost("/", async ([FromBody] CreateBranchMasterCommand command, IMediator mediator) =>
        {
            var response = await mediator.Send(command);
            return Results.Json(response, statusCode: response.StatusCode);
        });

        // UPDATE
        group.MapPut("/{id:int}", async (int id,
            [FromBody] UpdateBranchMasterCommand command,IMediator mediator) =>
        {
            command.BranchId = id;
            var response = await mediator.Send(command);
            return Results.Json(response, statusCode: response.StatusCode);
        });

        // DELETE
        group.MapDelete("/{id:int}", async (int id, IMediator mediator) =>
        {
            var response = await mediator.Send(new DeleteBranchMasterCommand(id));
            return Results.Json(response, statusCode: response.StatusCode);
        });
    }
}
