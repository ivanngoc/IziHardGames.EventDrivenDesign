using System.Threading;
using System.Threading.Tasks;

namespace IziHardGames.EventDrivenDesign.Abstractions
{
    public interface IRouterAsync
    {
        Task RouteAsync<T>(T msg, CancellationToken ct = default);
    }
}
