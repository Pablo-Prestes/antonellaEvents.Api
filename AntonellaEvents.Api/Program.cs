using ADoJob.Infra.IoC;
using AntonellaEvents.Infra.Data.Context;
using AntonellaEvents.Infra.IoC;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInsfrastructure(builder.Configuration);
builder.Services.AddInfrastructureSwagger();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

CreateAntonellaEventsReadContext(app);
CreateAntonellaEventsWriteContext(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void CreateAntonellaEventsWriteContext(WebApplication app)
{
	var serviceScope = app.Services.CreateScope();
	var dataContext = serviceScope.ServiceProvider.GetService<AntonellaEventsWriteContext>();
	dataContext?.Database.Migrate();
}

static void CreateAntonellaEventsReadContext(WebApplication app)
{
	var serviceScope = app.Services.CreateScope();
	var dataContext = serviceScope.ServiceProvider.GetService<AntonellaEventsReadContext>();
	dataContext?.Database.Migrate();
}