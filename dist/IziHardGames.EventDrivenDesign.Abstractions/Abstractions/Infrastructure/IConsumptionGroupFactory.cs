namespace IziHardGames.EventDrivenDesign.Abstractions.Infrastructure
{
    using System;

    public interface IConsumptionGroupFactory<TMessage, TMeta> where TMeta : IConsumerMetaDI
    {
        IConsumptionGroup<TMessage> Create(TMeta meta, Func<object> target);
    }
}
