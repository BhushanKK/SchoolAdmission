using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolAdmission.Application.Features.CasteMasters.Commands;
using SchoolAdmission.Application.Features.CasteMasters.Queries;

namespace SchoolAdmission.API.Endpoints;

public static class CasteMasterEndpoints
{
    public static void MapCasteMasterEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/castemaster");

        group.MapGet("/", async (IMediator mediator) =>
        {
            var result = await mediator.Send(new GetAllCasteMastersQuery());
            return Results.Ok(result);
        });

        group.MapGet("/{id:int}", async (int id, IMediator mediator) =>
        {
            var result = await mediator.Send(new GetCasteMasterByIdQuery(id));

            return result is null
                ? Results.NotFound(new { Message = "Caste not found" })
                : Results.Ok(result);
        });

        group.MapPost("/", async ([FromBody] CreateCasteMasterCommand command,IMediator mediator) =>
        {       
            var id = await mediator.Send(command);
            return Results.Created($"/api/castemaster/{id}", id);
        });

        group.MapPut("/{id:int}", async (int id,[FromBody] UpdateCasteMasterCommand command,IMediator mediator) =>
        {
            if (id != command.CasteId)
                return Results.BadRequest(new { Message = "Id mismatch" });

            var success = await mediator.Send(command);

            return success
                ? Results.NoContent()
                : Results.NotFound(new { Message = "Caste not found" });
        });

        group.MapDelete("/{id:int}", async (int id, IMediator mediator) =>
        {
            var success = await mediator.Send(new DeleteCasteMasterCommand(id));

            return success
                ? Results.NoContent()
                : Results.NotFound(new { Message = "Caste not found" });
        });
    }
}