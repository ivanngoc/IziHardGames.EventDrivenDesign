using System.Threading;
using System.Threading.Tasks;
using IziHardGames.EventDrivenDesign.Abstractions;

namespace IziHardGames.EventDrivenDesign.Application
{
    public class Router(EventsMap eventMap) : IRouterAsync
    {
        public Task RouteAsync<TEvent>(TEvent e, CancellationToken ct = default)
        {
            var t = typeof(TEvent);
            if (eventMap.TryGetValue(t, out var grp))
            {
                var faf = grp.ConsumeAsync(e!);
            }
            return Task.CompletedTask;
        }
    }
}
