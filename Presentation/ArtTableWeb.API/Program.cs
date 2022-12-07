using ArtTableWeb.Application;
using ArtTableWeb.Application.Exceptions;
using ArtTableWeb.Infrastructure;
using ArtTableWeb.Infrastructure.Filters;
using ArtTableWeb.Infrastructure.Services.Storage.Azure;
using ArtTableWeb.Infrastructure.Services.Storage.Local;
using ArtTableWeb.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Service Registration

builder.Services.AddPersistenceService();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddInfrastructureServices();

//Storage

builder.Services.AddStorage<LocalStorage>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureCustomExceptionMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
