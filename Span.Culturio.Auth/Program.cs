using Microsoft.EntityFrameworkCore;
using Span.Culturio.Auth.Data;
using Span.Culturio.Auth.Services;
using Span.Culturio.Microservices.Core;
//using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterSerilog();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.RegisterApiServices(builder.Configuration.GetSection("Jwt:Key").Value); // ova linija poziva funkciju koju smo napisali da doda automapper i ostalo u bilo koji mikroservis
builder.Services.RegisterHeaderPropagation();

//builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Culturio.Users"));
builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});



//servisi
builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();
app.UseHeaderPropagation();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(settings =>
    {
        settings.EnableTryItOutByDefault();
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

