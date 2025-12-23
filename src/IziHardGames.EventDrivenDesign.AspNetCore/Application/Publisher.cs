namespace IziHardGames.EventDrivenDesign.AspNetCore.Application
{
    using IziHardGames.EventDrivenDesign.Abstractions;

    public class Publisher(IRouterAsync router) : IPublisherAsync
    {
        public Task PublishAsync<TMsg>(TMsg msg, CancellationToken ct = default)
        {
            return router.RouteAsync(msg, ct);
        }
    }
}
