using IziHardGames.EventDrivenDesign.Abstractions;

namespace IziHardGames.EventDrivenDesign.AspNetCore.Application
{
    public class Publisher(IRouterAsync router) : IPublisherAsync
    {
        public Task PublishAsync<TMsg>(TMsg msg, CancellationToken ct = default)
        {
            return router.RouteAsync(msg, ct);
        }
    }
}
