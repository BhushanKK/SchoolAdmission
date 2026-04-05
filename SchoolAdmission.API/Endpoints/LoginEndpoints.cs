using MediatR;
using SchoolAdmission.Application.Features.Login.Commands;

namespace SchoolAdmission.API.Endpoints;

public static class LoginEndpoints
{
    public static void MapLoginEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/auth")
            .WithTags("Authentication")
            .RequireAuthorization()
            .WithDescription("Authentication endpoints");

        group.MapPost("/login",
        async (LoginCommand command, IMediator mediator) =>
        {
            var result = await mediator.Send(command);
            return Results.Ok(result);
        })
        .AllowAnonymous()
        .WithName("Login")
        .WithSummary("User login and JWT token generation");
    }
}
