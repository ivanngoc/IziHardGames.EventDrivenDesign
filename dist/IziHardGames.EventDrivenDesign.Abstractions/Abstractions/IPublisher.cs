namespace IziHardGames.EventDrivenDesign.Abstractions
{
    public interface IPublisher
    {
        void Publish<T>(T e);
    }
}
