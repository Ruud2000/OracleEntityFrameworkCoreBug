using Core8_23_40;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyDbContext8_23_40>((sp, options) =>
{
    options.UseOracle("User Id=MY_USER;Password=MY_USER;Data Source=localhost:1521/xe;", b =>
        b.UseOracleSQLCompatibility(OracleSQLCompatibility.DatabaseVersion21));
    options.EnableDetailedErrors(true);
});

var app = builder.Build();

app.MapGet("/8_23_40", (MyDbContext8_23_40 context) =>
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
