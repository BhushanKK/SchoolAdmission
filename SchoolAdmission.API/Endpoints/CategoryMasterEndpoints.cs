using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolAdmission.Application.Features.CategoryMasters.Commands;
using SchoolAdmission.Application.Features.CategoryMasters.Queries;

namespace SchoolAdmission.API.Endpoints;

public static class CategoryMasterEndpoints
{
    public static void MapCategoryMasterEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/Categorymasters")
        .WithTags("Category Master")
        .RequireAuthorization()
        .WithDescription("Endpoints for managing Category master data");

        
        group.MapGet("/", async (IMediator mediator) =>
        {
            var response = await mediator.Send(new GetAllCategoryMastersQuery());
            return Results.Json(response, statusCode: response.StatusCode);
        });

        
        group.MapGet("/{id:int}", async (int id, IMediator mediator) =>
        {
            var response = await mediator.Send(new GetCategoryMasterByIdQuery(id));
            return Results.Json(response, statusCode: response.StatusCode);
        });

        
        group.MapPost("/", async ([FromBody] CreateCategoryMasterCommand command, IMediator mediator) =>
        {
            var response = await mediator.Send(command);
            return Results.Json(response, statusCode: response.StatusCode);
        });

        
        group.MapPut("/{id:int}", async (int id, [FromBody] UpdateCategoryMasterCommand command, IMediator mediator) =>
        {
            command.CategoryId = id;
            var response = await mediator.Send(command);
            return Results.Json(response, statusCode: response.StatusCode);
        });

        
        group.MapDelete("/{id:int}", async (int id, IMediator mediator) =>
        {
            var response = await mediator.Send(new DeleteCategoryMasterCommand(id));
            return Results.Json(response, statusCode: response.StatusCode);
        });
    }
}

