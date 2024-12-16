using Application;
using BackgroundJobs;
using BackgroundJobs.Jobs;
using Hangfire;
using Hangfire.SqlServer;
using Persistence;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddApplicationCore();
builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.AddBackGroundJobsInfrastructure(builder.Configuration);

builder.Services.AddHangfire(config => config
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSqlServerStorage(builder.Configuration["Hangfire:ConnectionString"], new SqlServerStorageOptions
    {
        CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
        SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
        QueuePollInterval = TimeSpan.Zero,
        UseRecommendedIsolationLevel = true,
        DisableGlobalLocks = true
    })
);
builder.Services.AddHangfireServer();

var host = builder.Build();

using (var scope = host.Services.CreateScope())
{
    var recurringJobManager = scope.ServiceProvider.GetRequiredService<IRecurringJobManager>();

    recurringJobManager.AddOrUpdate<DataSyncJob>(
        "DataSyncJob",
        service => service.Run(),
        Cron.Minutely
    );
}

await host.RunAsync();
