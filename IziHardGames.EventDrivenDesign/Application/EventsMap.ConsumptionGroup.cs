namespace IziHardGames.EventDrivenDesign.Application
{
    using System;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using IziHardGames.EventDrivenDesign.Abstractions;
    using IziHardGames.EventDrivenDesign.Application.Metas;
    using F = System.Func<object, System.Threading.Tasks.Task>;

    public partial class EventsMap
    {
        public partial class ConsumptionGroup<T> : ConsumptionGroup
        {
            public ConsumptionGroup(Type eventType, ConsumerMetaT1[] metas, Item[] items) : base(eventType, metas, items)
            {

            }
        }

        public partial class ConsumptionGroup
        {
            public Type EventType { get; }
            public ConsumerMetaT1[] Metas { get; }
            internal Item[] Items { get; set; }

            public ConsumptionGroup(Type eventType, ConsumerMetaT1[] metas, Item[] items)
            {
                EventType = eventType;
                Metas = metas;
                Items = items;
            }

            public async Task ConsumeAsync(object e)
            {
                for (int i = 0; i < Items.Length; i++)
                {
                    await Items[i].Func(e).ConfigureAwait(false);
                }
            }

            public static Item CreateFunc(ConsumerMetaT1 consumer, Func<object> getTargetFunc)
            {
                var paramE = Expression.Parameter(typeof(object), "e");
                var paramFunc = Expression.Parameter(typeof(F), "arg");
                var method = typeof(ConsumptionGroup).GetMethod(nameof(ConsumeGenAsync), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
                var genericMethod = method!.MakeGenericMethod(consumer.meta.ImplementationType, consumer.meta.EventType);
                var call = Expression.Call(genericMethod, paramE, Expression.Constant(getTargetFunc));
                var lambda = Expression.Lambda<F>(call, paramE);
                var f = lambda.Compile();
                return new Item(f, getTargetFunc);
            }

            internal static Task ConsumeGenAsync<TTarget, TEvent>(object e, Func<object> getTargetFunc) where TTarget : IConsumerAsync<TEvent>
            {
                if (getTargetFunc() is TTarget target)
                {
                    return target.ConsumeAsync((TEvent)e);
                }
                return Task.CompletedTask;
            }
        }
    }
}