using FluentValidation;
using MediatR;
using SchoolAdmission.Application.Mappings;
using SchoolAdmission.Infrastructure.Interfaces;
using SchoolAdmission.Infrastructure.Repositories;

namespace SchoolAdmission.API.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // AutoMapper
        services.AddAutoMapper(typeof(CasteMasterProfile).Assembly);
        services.AddAutoMapper(typeof(CommiteMasterProfile).Assembly);
        services.AddAutoMapper(typeof(SchoolMasterProfile).Assembly);
        services.AddAutoMapper(typeof(CategoryMasterProfile).Assembly);
        services.AddAutoMapper(typeof(StandardMasterProfile).Assembly);
        services.AddAutoMapper(typeof(ReligionMasterProfile).Assembly); 
        services.AddAutoMapper(typeof(DivisionMasterProfile).Assembly);
        services.AddAutoMapper(typeof(FeesStructureProfile).Assembly);
        services.AddAutoMapper(typeof(BranchMasterProfile).Assembly);
         

        // FluentValidation
        services.AddValidatorsFromAssemblyContaining<CreateCategoryMasterHandler>();
        services.AddValidatorsFromAssemblyContaining<CreateCasteMasterHandler>();
        services.AddValidatorsFromAssemblyContaining<CreateStandardMasterHandler>();
        services.AddValidatorsFromAssemblyContaining<CreateReligionMasterHandler>();
        services.AddValidatorsFromAssemblyContaining<CreateFeesStructureHandler>();
        services.AddValidatorsFromAssemblyContaining<CreateDivisionMasterHandler>();
        services.AddValidatorsFromAssemblyContaining<CreateCommiteMasterHandler>();
        services.AddValidatorsFromAssemblyContaining<CreateSchoolMasterHandler>();
        services.AddValidatorsFromAssemblyContaining<CreateBranchMasterHandler>();
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICasteMasterRepository, CasteMasterRepository>();
        services.AddScoped<ICategoryMasterRepository, CategoryMasterRepository>();
        services.AddScoped<IStandardMasterRepository, StandardMasterRepository>();
        services.AddScoped<IDivisionMasterRepository, DivisionMasterRepository>();
        services.AddScoped<IReligionMasterRepository, ReligionMasterRepository>();
        services.AddScoped<IFeesStructureDetailsRepository, FeesStructureDetailsRepository>();
        services.AddScoped<ICommiteMasterRepository, CommiteMasterRepository>();
        services.AddScoped<ISchoolMasterRepository, SchoolMasterRepository>();
        services.AddScoped<IBranchMasterRepository, BranchMasterRepository>();
        services.AddScoped<IStudentDetailsRepository, StudentDetailsRepository>();
        services.AddScoped<IStudentUpdateRepository, StudentUpdateRepository>();
        services.AddScoped<IUserLoginRepository, UserLoginRepository>();
        services.AddScoped<IJwtRepository, JwtRepository>();

        return services;
    }
}

