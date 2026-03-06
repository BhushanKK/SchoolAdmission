using Serilog;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Application;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Repositories;
using SchoolAdmission.API.Endpoints;
using SchoolAdmission.Application.Behaviors;
using SchoolAdmission.Application.Mappings;
using FluentValidation;
using SchoolAdmission.Application.Validators;

var builder = WebApplication.CreateBuilder(args);

// Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Host.UseSerilog();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// MediatR (Correct Registration)
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly));

builder.Services.AddAutoMapper(typeof(CasteMasterProfile).Assembly);
builder.Services.AddAutoMapper(typeof(StandardMasterProfile).Assembly);

builder.Services.AddValidatorsFromAssemblyContaining<CreateCasteMasterCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateCategoryMasterCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateStandardMasterCommandValidator>();

// Add the validation pipeline BEFORE your TransactionBehavior
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));

// Repository
builder.Services.AddScoped<ICasteMasterRepository, CasteMasterRepository>();
builder.Services.AddScoped<ICategoryMasterRepository, ICategoryMasterRepository>();
builder.Services.AddScoped<IStandardMasterRepository, StandardMasterRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.MapCasteMasterEndpoints();

app.MapCategoryMasterEndpoints();

app.MapStandardMasterEndpoints();


app.Run();

internal interface ICategoryMasterRepository
{
}

internal class CreateCategoryMasterCommandValidator
{
}