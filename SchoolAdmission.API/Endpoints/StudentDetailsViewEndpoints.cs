using MediatR;
using SchoolAdmission.Application.Features.StudentDetails.Queries;

namespace SchoolAdmission.API.Endpoints;

public static class StudentDetailsViewEndpoints
{
    public static void MapStudentDetailsViewEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/student-details")
            .WithTags("Student Details View")
            .RequireAuthorization();

        group.MapGet("/", async (IMediator mediator) =>
        {
            var response = await mediator.Send(new GetAllStudentDetailsQuery());
            return Results.Json(response, statusCode: response.StatusCode);
        });
    }
}