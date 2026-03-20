using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolAdmission.Application.Features.CategoryMasters.Commands;
using SchoolAdmission.Application.Features.CategoryMasters.Queries;
using SchoolAdmission.Domain;

namespace SchoolAdmission.API.Endpoints;

public static class CategoryMasterEndpoints
{
    public static void MapCategoryMasterEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/Categorymasters")
        .WithTags("Category Master")
        .RequireAuthorization()
        .WithDescription("Endpoints for managing Category master data");

        // GET ALL
        group.MapGet("/", async (IMediator mediator) =>
        {
            var result = await mediator.Send(new GetAllCategoryMastersQuery());
            return Results.Ok
            (
                ApiResponse<List<CategoryMaster>>
                .SuccessResponse
                (
                    result, 
                    "Category retrieved successfully"
                )
            );    
        });

        // CREATE
        group.MapPost("/", async ([FromBody] CreateCategoryMasterCommand command, IMediator mediator) =>
        {
            var id = await mediator.Send(command);

            return Results.Ok(new
            {
                Success = true,
                Message = "Category created successfully",
                Data = id
            });
        });

        // GET BY ID
        group.MapGet("/{id:int}", async (int id, IMediator mediator) =>
        {
            var result = await mediator.Send(new GetCategoryMasterByIdQuery(id));

            return result is null
                ? Results.NotFound("Category not found")
                : Results.Ok
                (
                    ApiResponse<CategoryMaster>
                    .SuccessResponse
                    (
                        result, 
                        "Category retrieved successfully"
                    )
                );
        });

        // UPDATE By Id
        group.MapPut("/{id:int}", async (int id, [FromBody] UpdateCategoryMasterCommand command, IMediator mediator) =>
        {
            command.CategoryId = id;
            var success = await mediator.Send(command);

            return (bool)success!
                ? Results.Ok("Category updated successfully")
                : Results.NotFound("Category not found");
        });

        // DELETE By Id
        group.MapDelete("/{id:int}", async (int id, IMediator mediator) =>
        {
            var success = await mediator.Send(new DeleteCategoryMasterCommand(id));

            return success
                ? Results.Ok("Category deleted successfully")
                : Results.NotFound("Category not found");
        });
    }
}
