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
        app.MapStudentSignupEndpoints();
        app.MapStudentAddressEndpoints();
        app.MapStudentHealthEndpoints();
        app.MapStudentParentEndpoints();
        app.MapStudentDocumentEndpoints();
        app.MapStudentFeesEndpoints();
        app.MapStudentAcademicHistoryEndpoints();
        app.MapLoginEndpoints();

        return app;
    }
}
