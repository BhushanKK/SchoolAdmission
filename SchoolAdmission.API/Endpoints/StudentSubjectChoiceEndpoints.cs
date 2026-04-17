using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolAdmission.Application.Features.StudentSubjectChoice.Commands;
using SchoolAdmission.Application.Features.StudentSubjectChoice.Queries;

namespace SchoolAdmission.API.Endpoints;

public static class StudentSubjectChoiceEndpoints
{
    public static void MapStudentSubjectChoiceEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/StudentSubjectChoices")
        .WithTags("Student Subject Choice")
        .RequireAuthorization()
        .WithDescription("Endpoints for managing Student Subject Choice data");

        group.MapGet("/", async (IMediator mediator) =>
        {
            var response = await mediator.Send(new GetAllStudentSubjectChoiceQuery());
            return Results.Json(response, statusCode: response.StatusCode);
        });

        group.MapGet("/{id:int}", async (int id, IMediator mediator) =>
        {
            var response = await mediator.Send(new GetStudentSubjectChoiceByIdQuery(id));
            return Results.Json(response, statusCode: response.StatusCode);
        });


        group.MapPost("/", async ([FromBody] CreateStudentSubjectChoiceCommand command, IMediator mediator) =>
        {
            var response = await mediator.Send(command);
            return Results.Json(response, statusCode: response.StatusCode);
        });

        group.MapPut("/{id:int}", async (int id,
            [FromBody] UpdateStudentSubjectChoiceCommand command,
            IMediator mediator) =>
        {
            command.ChoiceId = id;

            var response = await mediator.Send(command);
            return Results.Json(response, statusCode: response.StatusCode);
        });

    }
}