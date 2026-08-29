using Microsoft.EntityFrameworkCore;
using SwaadExpress.DAL.Data;
using SwaadExpress.DAL.RegisterServices;
using SwaadExpress.DAL.CustomValidators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//Custom Validators
builder.Services.AddCustomValidators();

builder.Services.AddOpenApi();
// Enable Swagger/OpenAPI services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register DbContext before building the app
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//Register Dependencies
builder.Services.RegisterDependencies();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Use the standard Swagger middleware so the UI is served at /swagger

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
