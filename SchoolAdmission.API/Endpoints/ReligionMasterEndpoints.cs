using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolAdmission.Application.Features.ReligionMasters.Commands;
using SchoolAdmission.Application.Features.ReligionMasters.Queries;

namespace SchoolAdmission.API.Endpoints;

public static class ReligionMasterEndpoints
{
    public static void MapReligionMasterEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/religionmasters")
                       .WithTags("Religion Master")
                       .RequireAuthorization()
                       .WithDescription("Endpoints for managing Religion master data");

        
        group.MapGet("/", async (IMediator mediator) =>
        {
            var response = await mediator.Send(new GetAllReligionMastersQuery());
            return Results.Json(response, statusCode: response.StatusCode);
        });

        
        group.MapGet("/{id:int}", async (int id, IMediator mediator) =>
        {
            var response = await mediator.Send(new GetReligionMasterByIdQuery(id));
            return Results.Json(response, statusCode: response.StatusCode);
        });

        
        group.MapPost("/", async ([FromBody] CreateReligionMasterCommand command, IMediator mediator) =>
        {
            var response = await mediator.Send(command);
            return Results.Json(response, statusCode: response.StatusCode);
        });

        
        group.MapPut("/{id:int}", async (int id,
            [FromBody] UpdateReligionMasterCommand command, IMediator mediator) =>
        {
            command.ReligionId = id;
            var response = await mediator.Send(command);
            return Results.Json(response, statusCode: response.StatusCode);
        });

        
        group.MapDelete("/{id:int}", async (int id, IMediator mediator) =>
        {
            var response = await mediator.Send(new DeleteReligionMasterCommand(id));
            return Results.Json(response, statusCode: response.StatusCode);
        });
    }
}
