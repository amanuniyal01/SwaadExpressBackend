using Microsoft.EntityFrameworkCore;
using Resend;
using SwaadExpress.Application.Mappers;
using SwaadExpress.DAL.CustomValidators;
using SwaadExpress.DAL.Data;
using SwaadExpress.DAL.RegisterServices;
using SwaadExpress.Domain.Modal.Entity;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();


builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddHttpClient<ResendClient>();
builder.Services.Configure<ResendClientOptions>(o =>
{
    o.ApiToken = builder.Configuration["EmailSettings:ResendApiKey"];
});
builder.Services.AddTransient<IResend, ResendClient>();

//mapping to convert req to entity.
builder.Services.AddAutoMapper(typeof(MappingProfile));

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
