using System;
using System.Threading;
using System.Threading.Tasks;
using IziHardGames.AsyncCommunication.Contracts.EventDrivenDesign;

namespace IziHardGames.EventDrivenDesign.AspNetCore.Application
{
    public class Publisher(IRouter router) : IPublisher
    {
        public Task PublishAsync<TMsg>(TMsg msg, CancellationToken ct = default)
        {
            return router.RouteAsync(msg, ct);
        }
    }
}
