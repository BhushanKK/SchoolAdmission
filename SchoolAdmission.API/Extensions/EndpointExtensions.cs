using SchoolAdmission.API.Endpoints;

namespace SchoolAdmission.API.Extensions;

public static class EndpointExtensions
{
    public static IEndpointRouteBuilder MapMasterEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapCasteMasterEndpoints();
        app.MapCategoryMasterEndpoints();

        return app;
    }
}