using MassTransit;
using Microsoft.EntityFrameworkCore;
using Order.API.Context;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<OrderAPIContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("NPSQL")));

builder.Services.AddMassTransit(configurator => {
    configurator.UsingRabbitMq((context, _configure) =>
{
    _configure.Host(builder.Configuration["RabbitMQ"]);
}); });


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.Run();
