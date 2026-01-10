namespace IziHardGames.EventDrivenDesign.UnitTests
{
    using System.Threading.Tasks;
    using IziHardGames.EventDrivenDesign.Abstractions;
    using IziHardGames.EventDrivenDesign.Application;
    using IziHardGames.EventDrivenDesign.AspNetCore.Application;
    using IziHardGames.EventDrivenDesign.AspNetCore.Extensions;
    using Microsoft.Extensions.DependencyInjection;

    public class Publisher_UnitTest
    {
        [Fact]
        public void Should_Send_Struct_Without_Boxing()
        {
            var container = new ServiceCollection();
            container.AddSingleton<IPublisherAsync, Publisher>();
            container.AddSingleton<IRouterAsync, Router>();
            container.AddIziInMemoryMessaging();
            var services = container.BuildServiceProvider();

            var pub = services.GetRequiredService<IPublisher>();
            var cons = services.GetRequiredService<IConsumerAsync<StrAsEvent>>() as StructConsumer;
            Assert.NotNull(cons);
            pub.Publish(new StrAsEvent());
        }

        private struct StrAsEvent
        {
            public int ValInt0;
            public int ValInt1;
            public int ValInt2;
        }


        private class StructConsumer : IConsumerAsync<StrAsEvent>
        {
            public StrAsEvent e { get; private set; }

            public Task ConsumeAsync(StrAsEvent e)
            {
                this.e = e;
                return Task.CompletedTask;
            }
        }
    }
}
