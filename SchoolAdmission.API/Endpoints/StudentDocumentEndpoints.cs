using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolAdmission.Application.Features.StudentDocument.Queries;
using SchoolAdmission.Application.Features.StudentDocuments.Commands;

namespace SchoolAdmission.API.Endpoints;

public static class StudentDocumentEndpoints
{
    public static void MapStudentDocumentEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/student-document")
                       .WithTags("Student Document")
                       .RequireAuthorization()
                       .WithDescription("Endpoints for managing Student Document data");

        group.MapPost("/", async (
            [FromForm] SaveStudentDocumentCommand command,
            IMediator mediator) =>
        {
            var response = await mediator.Send(command);
            return Results.Json(response, statusCode: response.StatusCode);
        }).DisableAntiforgery();

        group.MapGet("/{studentId:guid}", async (Guid studentId, IMediator mediator) =>
        {
            var response = await mediator.Send(new GetStudentDocumentByStudentIdQuery(studentId));
            return Results.Json(response, statusCode: response.StatusCode);
        });
    }
}