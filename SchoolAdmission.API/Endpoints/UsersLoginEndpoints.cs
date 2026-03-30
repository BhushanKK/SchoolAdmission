using MediatR;
using SchoolAdmission.Application.Features.UserLogin.Commands.ActivateUser;
using SchoolAdmission.Application.Features.UsersLogin.Commands.DeactivateUser;

namespace SchoolAdmission.API.Endpoints;

public static class UsersLoginEndpoints
{
    public static void MapUsersLoginEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/users")
            .WithTags("Users Login")
            .RequireAuthorization()
            .WithDescription("User management endpoints");

        // ✅ Activate User
        group.MapPut("/activate/{studentId}",
        async (Guid studentId, IMediator mediator, CancellationToken cancellationToken) =>
        {
            var command = new ActivateUserCommand
            {
                StudentId = studentId
            };

            var result = await mediator.Send(command, cancellationToken);
            return Results.Ok(result);
        })
        .WithName("ActivateUser")
        .WithSummary("Activate student account");

        group.MapPut("/deactivate/{studentId}",
        async (Guid studentId, IMediator mediator, CancellationToken cancellationToken) =>
        {
            var command = new DeactivateUserCommand
            {
                StudentId = studentId
            };

            var result = await mediator.Send(command, cancellationToken);
            return Results.Ok(result);
        })
        .WithName("DeactivateUser")
        .WithSummary("Deactivate student account");
    }
}