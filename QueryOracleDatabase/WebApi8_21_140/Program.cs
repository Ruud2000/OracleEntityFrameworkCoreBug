using Core8_21_140;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyDbContext8_21_140>((sp, options) =>
{
    options.UseOracle("User Id=MY_USER;Password=MY_USER;Data Source=localhost:1521/xe;");
    options.EnableDetailedErrors(true);
});

var app = builder.Build();

app.MapGet("/8_21_140", (MyDbContext8_21_140 context) =>
{
    if (context.Customers.Any())
    {
        return "We have customers!";
    }
    else
    {
        return "We have no customers!";
    }
});

app.Run();
