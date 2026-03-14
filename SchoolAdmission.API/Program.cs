using Serilog;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using SchoolAdmission.Application;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Application.Behaviors;
using SchoolAdmission.API.Extensions;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// ⭐ Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Host.UseSerilog();

// ⭐ Swagger
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "School Admission API",
        Version = "v1"
    });

    // ⭐ ONLY define bearer input box
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Enter JWT like: Bearer {token}",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });
});

// ⭐ DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ⭐ MediatR
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly));

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));

// ⭐ Application Services
builder.Services.AddApplicationServices();
builder.Services.AddRepositories();

// ⭐ CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod());
});

// ⭐ JWT Authentication
builder.Services.AddAuthentication("Bearer")
.AddJwtBearer("Bearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],

        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Convert.FromBase64String(builder.Configuration["Jwt:Key"]!)),

        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,

        RoleClaimType = ClaimTypes.Role
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

// ⭐ Middleware Pipeline
app.UseSerilogRequestLogging();
app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.MapMasterEndpoints();

app.Run();