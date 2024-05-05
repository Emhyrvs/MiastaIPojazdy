using Microsoft.EntityFrameworkCore;
using Projekt_Rekrutajca.Data;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(opt =>
                     opt.UseInMemoryDatabase("InMem"));

builder.Services.AddScoped<ICityRepo,CityRepo>();   
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API", Version = "v1" });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
    c.RoutePrefix = string.Empty; // Dla dost?pu do Swagger UI pod g?ównym adresem
});

app.UseHttpsRedirection();
PrepDb.PrepPopulation(app);

app.UseAuthorization();

app.MapControllers();

app.Run();
