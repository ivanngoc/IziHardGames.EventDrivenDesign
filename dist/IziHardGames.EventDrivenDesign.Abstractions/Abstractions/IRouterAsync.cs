namespace IziHardGames.EventDrivenDesign.Abstractions
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface IRouterAsync
    {
        Task RouteAsync<T>(T msg, CancellationToken ct = default);
    }
}
