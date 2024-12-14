using Application.Services;
using BackgroundJobs.Jobs;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BackgroundJobs
{
    public static class ServiceExtension
    {
        public static void AddBackGroundJobsInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHostedService<DataSyncJob>();
            services.AddHttpClient<IExternalApiService<Card>, ExternalCardApiService>();
        }
    }
}
