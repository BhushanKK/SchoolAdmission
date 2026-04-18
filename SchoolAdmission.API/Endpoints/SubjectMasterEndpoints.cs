using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolAdmission.Application.Features.BranchMasters.Commands;
using SchoolAdmission.Application.Features.SubjectMasters.Commands;
using SchoolAdmission.Application.Features.SubjectMasters.Queries;

namespace SchoolAdmission.API.Endpoints;

public static class SubjectMasterEndpoints
{
    public static void MapSubjectMasterEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/Subjectmasters")
        .WithTags("Subject Master")
        .RequireAuthorization()
        .WithDescription("Endpoints for managing Subject master data");

        group.MapGet("/", async (IMediator mediator) =>
        {
            var response = await mediator.Send(new GetAllSubjectMasterQuery());
            return Results.Json(response, statusCode: response.StatusCode);
        });

        group.MapGet("/subjectsByBranchId/{branchId:int}", async (int branchId, IMediator mediator) =>
        {
            var response = await mediator.Send(new GetSubjectsGroupedByBranchQuery(branchId));
            return Results.Json(response, statusCode: response.StatusCode);
        });

        group.MapGet("/{id:int}", async (int id, IMediator mediator) =>
        {
            var response = await mediator.Send(new GetSubjectMasterByIdQuery(id));
            return Results.Json(response, statusCode: response.StatusCode);
        });

        group.MapPost("/", async ([FromBody] CreateSubjectMasterCommand command, IMediator mediator) =>
        {
            var response = await mediator.Send(command);
            return Results.Json(response, statusCode: response.StatusCode);
        });

        group.MapPut("/{id:int}", async (int id,
            [FromBody] UpdateSubjectMasterCommand command, IMediator mediator) =>
        {
            command.SubjectId = id;
            var response = await mediator.Send(command);
            return Results.Json(response, statusCode: response.StatusCode);
        });


    }
}