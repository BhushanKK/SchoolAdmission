using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Application.Features.CategoryMasters.Commands;
using SchoolAdmission.Application.Features.CategoryMasters.Queries;

namespace SchoolAdmission.API.Endpoints;

public static class CategoryMasterEndpoints
{
    public static void MapCategoryMasterEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/categorymasters")
        .WithTags("Category Master")
        .WithDescription("Endpoints for managing category master data");

        // GET ALL
        group.MapGet("/", async (IMediator mediator) =>
        {
            var result = await mediator.Send(new GetAllCategoryMastersQuery());
            return Results.Ok(ApiResponse<List<CategoryMaster>>.SuccessResponse(result, "Category retrieved successfully"));
        });

        // GET BY ID
        group.MapGet("/{id:int}", async (int id, IMediator mediator) =>
        {
            var result = await mediator.Send(new GetCategoryMasterByIdQuery(id));

            return result is null
                ? Results.NotFound(ApiResponse<CategoryMasterQueryDto>.FailureResponse("Category not found"))
                : Results.Ok(ApiResponse<CategoryMasterQueryDto>.SuccessResponse(result, "Category retrieved successfully"));
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

        // UPDATE
        group.MapPut("/{id:int}", async (int id, [FromBody] UpdateCategoryMasterCommand command, IMediator mediator) =>
        {
            command.CategoryId = id;
            var success = await mediator.Send(command);

            if ((bool)success!)
            {
                return Results.Ok(new
                {
                    Success = true,
                    Message = "Category updated successfully",
                    Data = id
                });
            }

            return Results.NotFound(new
            {
                Success = false,
                Message = "Category not found",
                Data = (int?)null
            });
        });

        // DELETE
        group.MapDelete("/{id:int}", async (int id, IMediator mediator) =>
        {
            var success = await mediator.Send(new DeleteCategoryMasterCommand(id));

            if (success)
            {
                return Results.Ok(new
                {
                    Success = true,
                    Message = "Category deleted successfully",
                    Data = id
                });
            }

            return Results.NotFound(new
            {
                Success = false,
                Message = "Category not found",
                Data = (int?)null
            });
        });
    }
}
