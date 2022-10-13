using CustomerWebAPI;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var dbHost = @"(LocalDb)\MSSQLLocalDB";
var dbName = "dms_customer";
var dbPassword = "P@ssw0rd121#";
var connectionString = $"Data Source={dbHost}; Initial Catalog={dbName}; Integrated Security=True;";
builder.Services.AddDbContext<CustomerDbContext>(opt => opt.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
