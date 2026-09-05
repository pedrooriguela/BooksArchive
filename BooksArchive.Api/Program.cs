using BooksArchive.Api.Infra.Database;
using BooksArchive.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using BooksArchive.Domain.Services;
using BooksArchive.Domain.Interfaces;
using BooksArchive.Infra.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BooksArchiveDbContext>(options =>
    options.UseNpgsql(builder.Configuration["PostgresSettings:ConnectionString"]));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserLoginService, UserLoginService>();
builder.Services.AddScoped<IPasswordHasherService, PasswordHasherService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod());
});

builder.Services.AddControllers();
builder.Services.AddOpenApi();          

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();                   
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "BooksArchive API v1");
    });
}

app.UseCors("AllowFrontend");
app.MapControllers();

app.Run();