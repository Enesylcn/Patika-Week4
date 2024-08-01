using System.Reflection;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Patika.WebApi;
using Patika.WebApi.Common;
using Patika.WebApi.DBOperations;
using Patika.WebApi.Middlewares;
using Patika.WebApi.Services;
using Patika.WebApi.Validation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Patika-WebApi", Version = "v1" });
});



builder.Services.AddDbContext<BookStoreDbContext>(options => options.UseInMemoryDatabase("BookStoreDB"));
builder.Services.AddScoped<IBookStoreDbContext>(provider => provider.GetService<BookStoreDbContext>());
var config = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
builder.Services.AddSingleton(config.CreateMapper());

builder.Services.AddSingleton<ILoggerService, ConsoleLogger>();

var app = builder.Build();

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    DataGenerator.Initialize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Patika-WebApi V1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCustomExeptionMiddleware();
app.MapControllers();

app.Run();
