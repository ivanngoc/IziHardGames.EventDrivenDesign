using IziHardGames.EventDrivenDesign.Abstractions;
using IziHardGames.EventDrivenDesign.Application;
using IziHardGames.EventDrivenDesign.AspNetCore.Application.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace IziHardGames.EventDrivenDesign.UnitTests
{
    public class ReflectionHelper_UnitTest
    {

        [Fact]

        public void Shoud_Regist_Types()
        {
            var container = new ServiceCollection();
            container.AddSingleton<IServiceCollection>(container);
            container.AddSingleton<ConsumerStr>();
            container.AddSingleton<ConsumerInt>();
            var service = container.BuildServiceProvider();
            var map = DIReflectionHelper.GetEventMap(service);
            var intConsumer = map[typeof(int)];
            var stringConsumer = map[typeof(string)];
            Assert.Equal(typeof(ConsumerInt), intConsumer.Metas.First().meta.ImplementationType);
            Assert.Equal(typeof(ConsumerStr), stringConsumer.Metas.First().meta.ImplementationType);
        }

        [Fact]
        public void Should_FindTypes()
        {
            var etor = ReflectionHelper.GetConsumerMetasEnumerable(typeof(ConsumerStr).Assembly);
            var count = 0;
            foreach (var item in etor)
            {
                count++;
                if (item.ImplementationType == typeof(ConsumerStr))
                {
                    Assert.Equal(typeof(string), item.EventType);
                }
                else if (item.ImplementationType == typeof(ConsumerInt))
                {
                    Assert.Equal(typeof(int), item.EventType);
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            Assert.Equal(2, count);
        }

        private class ConsumerStr : IConsumerAsync<string>
        {
            public async Task ConsumeAsync(string e)
            {
                await Task.CompletedTask;
            }
        }

        private class ConsumerInt : IConsumerAsync<int>
        {
            public async Task ConsumeAsync(int e)
            {
                await Task.CompletedTask;
            }
        }
    }
}
