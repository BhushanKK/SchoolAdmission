using FluentValidation;
using SchoolAdmission.Application.Mappings;
using SchoolAdmission.Application.Validators;
using SchoolAdmission.Infrastructure.Repositories;

namespace SchoolAdmission.API.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // AutoMapper
        services.AddAutoMapper(typeof(CasteMasterProfile).Assembly);

        // FluentValidation
        services.AddValidatorsFromAssemblyContaining<CreateCasteMasterCommandValidator>();

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICasteMasterRepository, CasteMasterRepository>();
        services.AddScoped<ICategoryMasterRepository, CategoryMasterRepository>();

        return services;
    }
}