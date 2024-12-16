using Application;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationCore();
builder.Services.AddPersistenceInfrastructure(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddCors(
    options =>
    {
        var frontendURL = builder.Configuration.GetValue<string>("frontend_url");

        options.AddDefaultPolicy(builder =>
        {
            builder.WithOrigins(frontendURL!).AllowAnyMethod().AllowAnyHeader();
        });
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
