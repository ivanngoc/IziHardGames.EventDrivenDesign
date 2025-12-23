namespace IziHardGames.EventDrivenDesign.Abstractions
{
    public interface IConsumer
    {

    }

    public interface IConsumer<T> : IConsumer
    {
        void Consume(T e);
    }
}
