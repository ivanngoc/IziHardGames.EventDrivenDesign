using IziHardGames.EventDrivenDesign.Abstractions;
using IziHardGames.EventDrivenDesign.Application;

namespace IziHardGames.EventDrivenDesign.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Should_FindTypes()
        {
            var etor = ReflectionHelper.GetConsumerMetasEnumerable(typeof(ConsumerStr).Assembly);
            var count = 0;
            foreach (var item in etor)
            {
                count++;
                if (item.ActulaType == typeof(ConsumerStr))
                {
                    Assert.Equal(typeof(string), item.EventType);
                }
                else if (item.ActulaType == typeof(ConsumerInt))
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
