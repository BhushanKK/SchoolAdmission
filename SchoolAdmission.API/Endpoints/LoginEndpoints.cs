using MediatR;
using SchoolAdmission.Application.Features.Login.Commands;

namespace SchoolAdmission.API.Endpoints;

public static class LoginEndpoints
{
    public static void MapLoginEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/login")
        .WithTags("Login")
        .WithDescription("Endpoints for managing login functionality");

        group.MapPost("/GenerateToken", async (LoginCommand command, IMediator mediator) =>
        {
            return Results.Ok(await mediator.Send(command));
        });

        group.MapPost("/refresh-token", async (RefreshTokenCommand command, IMediator mediator) =>
        {
            return Results.Ok(await mediator.Send(command));
        });
    }
}

