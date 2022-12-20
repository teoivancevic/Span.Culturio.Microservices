﻿using Microsoft.EntityFrameworkCore;
using Span.Culturio.Microservices.Core;
using Span.Culturio.Microservices.Subscriptions.Data;
using Span.Culturio.Microservices.Subscriptions.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.RegisterApiServices(builder.Configuration.GetSection("Jwt:Key").Value); // ova linija poziva funkciju koju smo napisali da doda automapper i ostalo u bilo koji mikroservis

//builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Culturio.Users"));
builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();


var app = builder.Build();

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

