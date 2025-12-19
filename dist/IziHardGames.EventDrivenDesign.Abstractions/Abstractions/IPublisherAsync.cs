namespace IziHardGames.EventDrivenDesign.Abstractions
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface IPublisherAsync
    {
        Task PublishAsync<T>(T e, CancellationToken ct = default);
    }
}
