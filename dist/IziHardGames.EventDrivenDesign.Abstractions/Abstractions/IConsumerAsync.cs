namespace IziHardGames.EventDrivenDesign.Abstractions
{
    using System.Threading.Tasks;
    public interface IConsumerAsync<T> : IConsumer
    {
        Task ConsumeAsync(T e);
    }
}
