using Serilog;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Application;
using SchoolAdmission.Application.Common.Interfaces;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Repositories;
using SchoolAdmission.API.Endpoints;

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

// Repository
builder.Services.AddScoped<ICasteMasterRepository, CasteMasterRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.MapCasteMasterEndpoints();

app.Run();