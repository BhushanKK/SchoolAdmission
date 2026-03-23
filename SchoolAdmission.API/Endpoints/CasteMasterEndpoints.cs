using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolAdmission.Application.Features.CasteMasters.Commands;
using SchoolAdmission.Application.Features.CasteMasters.Queries;

namespace SchoolAdmission.API.Endpoints;

public static class CasteMasterEndpoints
{
    public static void MapCasteMasterEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/castemaster")
        .WithTags("Caste Master")
        .RequireAuthorization()
        .WithDescription("Endpoints for managing caste master data");

        
        group.MapGet("/", async (IMediator mediator) =>
        {
            var result = await mediator.Send(new GetAllCasteMasterQuery());
            return Results.Json(result, statusCode: result.StatusCode);
        });

        
        group.MapGet("/{id:int}", async (int id, IMediator mediator) =>
        {
            var result = await mediator.Send(new GetCasteMasterByIdQuery(id));
            return Results.Json(result, statusCode: result.StatusCode);
        });

        
        group.MapPost("/", async ([FromBody] CreateCasteMasterCommand command, IMediator mediator) =>
        {
            var response = await mediator.Send(command);
            return Results.Json(response, statusCode: response.StatusCode);
        });

        
        group.MapPut("/{id:int}", async (int id, [FromBody] UpdateCasteMasterCommand command, IMediator mediator) =>
        {

            command.CasteId = id; 
            var response = await mediator.Send(command);
            return Results.Json(response, statusCode: response.StatusCode);
        });

        
        group.MapDelete("/{id:int}", static async (int id, IMediator mediator) =>
        {
            var response = await mediator.Send(new DeleteCasteMasterCommand(id));

            return Results.Json(response, statusCode: response.StatusCode);
        });
    }  
}
