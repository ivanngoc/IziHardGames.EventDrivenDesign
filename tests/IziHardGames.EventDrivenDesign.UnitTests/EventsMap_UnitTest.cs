using IziHardGames.EventDrivenDesign.Abstractions;

namespace IziHardGames.EventDrivenDesign.UnitTests
{
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class EventsMap_UnitTest
    {
        [Fact]
        public void Should_Create_EventMap()
        {
            var consumer = new Consumer();
            var consumerParam = Expression.Parameter(typeof(IConsumer<EventsMap_UnitTest>), "c");
            var eventParam = Expression.Parameter(typeof(EventsMap_UnitTest), "e");
            var method = typeof(IConsumer<>).MakeGenericType(typeof(EventsMap_UnitTest)).GetMethod(nameof(IConsumer<>.Consume));
            Assert.NotNull(method);
            // consumer.Consume(eventParam)
            var call = Expression.Call(consumerParam, method, eventParam);
            var lambda = Expression.Lambda<Action<IConsumer<EventsMap_UnitTest>, EventsMap_UnitTest>>(
                   call,
                   consumerParam,
                   eventParam);
            var func = lambda.Compile();
            Assert.Throws<InvalidOperationException>(() => { func(consumer, this); });
        }

        class Consumer : IConsumer<EventsMap_UnitTest>
        {
            public void Consume(EventsMap_UnitTest e)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
