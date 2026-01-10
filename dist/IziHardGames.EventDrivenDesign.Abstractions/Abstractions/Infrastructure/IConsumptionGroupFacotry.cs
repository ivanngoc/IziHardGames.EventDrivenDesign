namespace IziHardGames.EventDrivenDesign.Abstractions.Infrastructure
{
    using System;

    public interface IConsumptionGroupFacotry<T, TMeta>
    {
        T Create(TMeta meta, Func<object> target);
    }
}
