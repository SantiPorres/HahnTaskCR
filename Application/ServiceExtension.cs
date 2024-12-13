using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServiceExtension
{
    public static void AddApplicationCore(this IServiceCollection services)
    {
        #region Services

        services.AddScoped<IDataFetchingService, DataFetchingService>();

        #endregion
    }
}