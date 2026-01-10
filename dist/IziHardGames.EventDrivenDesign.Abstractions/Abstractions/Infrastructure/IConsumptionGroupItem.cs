namespace IziHardGames.EventDrivenDesign.Abstractions.Infrastructure
{
    public interface IConsumptionGroupItem<TMessage>
    {
        void Consume(TMessage message);
    }
}
