namespace IziHardGames.EventDrivenDesign.Abstractions.Infrastructure
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface IConsumptionGroupItemAsync<TMessage>
    {
        Task ConsumeAsync(TMessage message, CancellationToken ct = default);
    }
}
