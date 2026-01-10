namespace IziHardGames.EventDrivenDesign.Abstractions.Infrastructure
{
    public interface IConsumptionGroup<TMessage>
    {
        void Consume(TMessage e);
    }
}
