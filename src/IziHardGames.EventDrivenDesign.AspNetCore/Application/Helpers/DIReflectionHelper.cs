namespace IziHardGames.EventDrivenDesign.AspNetCore.Application.Helpers
{
    using IziHardGames.EventDrivenDesign.Abstractions;
    using IziHardGames.EventDrivenDesign.Application;
    using IziHardGames.EventDrivenDesign.Application.Metas;
    using IziHardGames.EventDrivenDesign.AspNetCore.Extensions;
    using Microsoft.Extensions.DependencyInjection;
    using static IziHardGames.EventDrivenDesign.Application.EventsMap;
    using static IziHardGames.EventDrivenDesign.Application.EventsMap.ConsumptionGroup;

    public class DIReflectionHelper
    {
        public static EventsMap GetEventMap(IServiceProvider services)
        {
            IEnumerable<ConsumerMetaT1> eble;
            var container = services.GetService<IServiceCollection>();
            if (container is not null)
            {
                var metas = new List<ConsumerMetaT1>();
                eble = metas;
                foreach (var item in container)
                {
                    var actualType = item.ImplementationType;
                    if (item.Lifetime == ServiceLifetime.Singleton && actualType is not null)
                    {
                        var ifaces = actualType.GetInterfaces();
                        foreach (var iface in ifaces)
                        {
                            if (iface.IsGenericType && iface.GetGenericTypeDefinition() == typeof(IConsumerAsync<>))
                            {
                                var eType = iface.GetGenericArguments()[0];
                                metas.Add(new(new(actualType, eType, iface), item.ServiceType));
                            }
                        }
                    }
                }
            }
            else
            {
                var metas = GetConsumerMetas(services);
                eble = metas;
            }
            var pairs = GetPairs(eble, services);
            var result = new EventsMap(eble, pairs);
            return result;
        }

        public static ConsumerMetaT1[] GetConsumerMetas(IServiceProvider provider)
        {
            var descr = provider.GetDescriptors();
            if (descr is null)
            {
                throw new InvalidOperationException();
            }
            var metas = descr.SelectMany(x => ExtractMetas(x)).ToArray();
            return metas;
        }

        private static IEnumerable<ConsumerMetaT1> ExtractMetas(IServiceCollection services)
        {
            throw new NotImplementedException();
        }

        private static IEnumerable<ConsumerMetaT1> ExtractMetas(ServiceDescriptor descriptor)
        {
            var actualType = descriptor.ServiceType;
            var declaredType = descriptor.ServiceType;
            var interfaces = actualType.GetInterfaces();

            foreach (var iface in interfaces)
            {
                if (typeof(IConsumer).IsAssignableFrom(iface))
                {
                    if (iface.IsGenericType && iface.GetGenericTypeDefinition() == typeof(IConsumerAsync<>))
                    {
                        var eventType = iface.GetGenericArguments().First();
                        yield return new ConsumerMetaT1(new ConsumerMeta(actualType, eventType, iface), declaredType);
                    }
                }
            }
        }

        private static IEnumerable<KeyValuePair<Type, ConsumptionGroup>> GetPairs(IEnumerable<ConsumerMetaT1> enumerable, IServiceProvider services)
        {
            var byEvents = enumerable.GroupBy(x => x.meta.EventType).Select(x =>
            {
                var items = CreateFuncs(x, services);
                var cg = new ConsumptionGroup(x.Key, x.ToArray(), items);
                return cg;
            });
            return byEvents.Select(x => new KeyValuePair<Type, ConsumptionGroup>(x.EventType, x));
        }

        private static Item[] CreateFuncs(IEnumerable<ConsumerMetaT1> metas, IServiceProvider services)
        {
            return metas.Select(x =>
            {
                var f = () => services.GetService(x.registeredAs);
                return CreateFunc(x, f);
            }).ToArray();
        }
    }
}
