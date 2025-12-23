namespace IziHardGames.EventDrivenDesign.AspNetCore.Extensions
{
    using System.Reflection;
    using Microsoft.Extensions.DependencyInjection;

    public static class IServiceProviderExtensions
    {
        public static ServiceDescriptor[]? GetDescriptors(this IServiceCollection services)
        {
            if (services is ServiceCollection sc)
            {

            }
            throw new NotImplementedException();
        }

        public static ServiceDescriptor[]? GetDescriptors(this IServiceProvider services)
        {
            if (services is ServiceProvider sp)
            {
                throw new NotImplementedException();
            }
            else
            {
                var type = services.GetType();
                var propInfo = type.GetProperty("RootProvider", BindingFlags.Instance | BindingFlags.NonPublic);
                if (propInfo is not null)
                {
                    var servProvider = propInfo.GetValue(services);
                    if (servProvider is not null)
                    {
                        var propCallSiteFactory = servProvider.GetType().GetProperty("CallSiteFactory", BindingFlags.NonPublic | BindingFlags.Instance);
                        if (propCallSiteFactory is not null)
                        {
                            var callSiteFactory = propCallSiteFactory.GetValue(servProvider);
                            if (callSiteFactory is not null)
                            {
                                var propDescriptors = callSiteFactory.GetType().GetProperty("Descriptors", BindingFlags.Instance | BindingFlags.NonPublic);
                                if (propDescriptors is not null)
                                {
                                    var descr = propDescriptors.GetValue(callSiteFactory);
                                    var casted = descr as ServiceDescriptor[];
                                    if (casted is null && descr is not null)
                                    {
                                        throw new InvalidCastException($"expected {typeof(ServiceDescriptor).FullName} but {descr.GetType().AssemblyQualifiedName}");
                                    }
                                    return casted;
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }
    }
}
