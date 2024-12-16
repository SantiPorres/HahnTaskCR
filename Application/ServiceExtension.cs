using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServiceExtension
{
    public static void AddApplicationCore(this IServiceCollection services)
    {
        #region Services

        services.AddScoped<IExternalApiService<Card>, ExternalCardApiService>();
        services.AddHttpClient<IExternalApiService<Card>, ExternalCardApiService>();

        #endregion
    }
}