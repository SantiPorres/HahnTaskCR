using Application;
using BackgroundJobs;
using Persistence;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddApplicationCore();
builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.AddBackGroundJobsInfrastructure(builder.Configuration);

var host = builder.Build();
await host.RunAsync();
