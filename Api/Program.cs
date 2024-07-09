using Application;
using Carter;
using Domain.Entities;
using Infrastructure.ServiceCollections;
using Marten;
using Marten.Events.Projections;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Marten
builder.Services.AddMarten(options =>
{
  options.Connection(builder.Configuration.GetConnectionString("MartenDb"));
  options.Projections.Add<UserProjection>(ProjectionLifecycle.Inline);
});

builder.Services.AddInfrastructure();

builder.Services.AddCarter();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Mediatr).Assembly));

var app = builder.Build();

app.MapCarter();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
