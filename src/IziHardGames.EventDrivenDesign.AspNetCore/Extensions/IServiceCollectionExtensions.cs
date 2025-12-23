namespace IziHardGames.EventDrivenDesign.AspNetCore.Extensions
{
    using IziHardGames.EventDrivenDesign.Abstractions;
    using IziHardGames.EventDrivenDesign.Application;
    using IziHardGames.EventDrivenDesign.AspNetCore.Application;
    using IziHardGames.EventDrivenDesign.AspNetCore.Application.Helpers;
    using Microsoft.Extensions.DependencyInjection;

    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddIziInMemoryMessaging(this IServiceCollection services)
        {
            if (!services.Any(x => x.ServiceType == typeof(IServiceCollection)))
            {
                services.AddSingleton(services);
            }
            services.AddSingleton(x => DIReflectionHelper.GetEventMap(x));
            services.AddSingleton<IRouterAsync, Router>();
            services.AddSingleton<IPublisherAsync, Publisher>();
            return services;
        }
    }
}
