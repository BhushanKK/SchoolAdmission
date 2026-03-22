using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolAdmission.Application.Features.SchoolMasters.Commands;
using SchoolAdmission.Application.Features.SchoolMasters.Queries;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.API.Endpoints;

public static class SchoolMasterEndpoints
{
    public static void MapSchoolMasterEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/Schoolmaster")
        .WithTags("School Master")
        .RequireAuthorization()
        .WithDescription("Endpoints for managing school master data");

        // Lookup endpoint (for dropdowns, etc.)
        group.MapGet("/", async (IMediator mediator) =>
        {
            var result = await mediator.Send(new GetAllSchoolMastersQuery());
            return Results.Ok(ApiResponse<List<SchoolMasterQueryDto>>.SuccessResponse(result, "School retrieved successfully"));
        });

        // Get by Id
        group.MapGet("/{id:int}", async (int id, IMediator mediator) =>
        {
            var result = await mediator.Send(new GetSchoolMasterByIdQuery(id));

            return result is null
                ? Results.NotFound(ApiResponse<SchoolMasterQueryDto>.FailureResponse("School not found"))
                : Results.Ok(ApiResponse<SchoolMasterQueryDto>.SuccessResponse(result, "School Details retrieved successfully"));
        });

        // Create
        group.MapPost("/", async ([FromBody] CreateSchoolMasterCommand command, IMediator mediator) =>
        {
            var id = await mediator.Send(command);
            return Results.Ok(new
            {
                success = true,
                message = "School created successfully",
                data = id
            });
        });

        // Update
        group.MapPut("/{id:int}", async (int id, [FromBody] UpdateSchoolMasterCommand command, IMediator mediator) =>
        {

            command.SchoolId = id; // Ensure the ID from the route is used
            var success = await mediator.Send(command);

            return success
                ? Results.Ok(ApiResponse<object>.SuccessResponse(null, "School Details updated successfully"))
                : Results.NotFound(ApiResponse<object>.FailureResponse("School not found"));

        });

        // Delete
        group.MapDelete("/{id:int}", static async (int id, IMediator mediator) =>
        {
            var success = await mediator.Send(new DeleteSchoolMasterCommand(id));

            return success

                ? Results.Ok(ApiResponse<object>.SuccessResponse(null, "School Details deleted successfully"))
                : Results.NotFound(ApiResponse<object>.FailureResponse("School not found"));

                
        });
    }
}