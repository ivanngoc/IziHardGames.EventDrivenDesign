using IziHardGames.AsyncCommunication.Application.EventDrivenDesign;
using IziHardGames.AsyncCommunication.Contracts.EventDrivenDesign;
using IziHardGames.EventDrivenDesign.AspNetCore.Application;
using IziHardGames.EventDrivenDesign.AspNetCore.Application.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace IziHardGames.EventDrivenDesign.AspNetCore.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddIziInMemoryMessaging(this IServiceCollection services)
        {
            services.AddSingleton(x => DIReflectionHelper.GetEventMap(x));
            services.AddSingleton<IRouter, Router>();
            services.AddSingleton<IPublisher, Publisher>();
            return services;
        }
    }
}
