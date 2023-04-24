using EcommerceAPI.SignalR.HubServices;
using ECommerceAPI.Application.Abstractions.Hubs;
using Microsoft.Extensions.DependencyInjection;

namespace EcommerceAPI.SignalR
{
    public static class ServiceRegistration
    {
        public static void AddSignalRServices(this IServiceCollection collection)
        {
            collection.AddTransient<IProductHubService, ProductHubService>();
            collection.AddSignalR();
        }
    }
}
