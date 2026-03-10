using SchoolAdmission.API.Endpoints;

namespace SchoolAdmission.API.Extensions;

public static class EndpointExtensions
{
    public static IEndpointRouteBuilder MapMasterEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapCasteMasterEndpoints();
        app.MapCategoryMasterEndpoints();
        app.MapStandardMasterEndpoints();
        app.MapDivisionMasterEndpoints();
        app.MapReligionMasterEndpoints();
        app.MapFeesStructureEndpoints();
        app.MapCommiteMasterEndpoints();
        app.MapSchoolMasterEndpoints();
        app.MapBranchMasterEndpoints();

        return app;
    }
}