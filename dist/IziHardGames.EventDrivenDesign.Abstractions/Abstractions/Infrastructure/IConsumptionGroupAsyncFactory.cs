namespace IziHardGames.EventDrivenDesign.Abstractions.Infrastructure
{
    using System;

    public interface IConsumptionGroupAsyncFactory<TMessage, TMeta>
        where TMeta : IConsumerMetaDI
    {
        IConsumptionGroupAsync<TMessage> Create(TMeta meta, Func<object> target);
    }
}
