using MediatR;
using SchoolAdmission.Application.Features.UsersLogin.Commands.StudentActiveDeactive;

namespace SchoolAdmission.API.Endpoints;

public static class UsersLoginEndpoints
{
    public static void MapUsersLoginEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/users")
            .WithTags("Users Login")
            .RequireAuthorization()
            .WithDescription("User management endpoints");

        group.MapPut("/student-status/{studentId}/{status}",
        async (Guid studentId, bool status, IMediator mediator, CancellationToken cancellationToken) =>
        {
            var command = new StudentActiveDeactiveCommand
            {
                StudentId = studentId,
                Status = status // true = activate, false = deactivate
            };

            var result = await mediator.Send(command, cancellationToken);
            return Results.Ok(result);
        })
        .WithName("StudentActiveDeactive");
    }
}