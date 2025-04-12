using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using Microsoft.OpenApi.Models;
using IndividueelProject.WebApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Your API",
        Version = "v1"
    });
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();

builder.Configuration.AddUserSecrets<Program>();
builder.Services.AddSingleton<IDbConnection>(sp =>
    new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton<UserRepository>();
builder.Services.AddSingleton<ObjectRepository>();
builder.Services.AddSingleton<WorldRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API v1");
        c.RoutePrefix = string.Empty; // Swagger at root URL
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
