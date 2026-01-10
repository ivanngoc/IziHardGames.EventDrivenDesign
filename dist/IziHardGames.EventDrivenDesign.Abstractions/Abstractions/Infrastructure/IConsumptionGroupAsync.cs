namespace IziHardGames.EventDrivenDesign.Abstractions.Infrastructure
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface IConsumptionGroupAsync<TMessage>
    {
        Task ConsumeAsync(TMessage e, CancellationToken ct);
    }
}
