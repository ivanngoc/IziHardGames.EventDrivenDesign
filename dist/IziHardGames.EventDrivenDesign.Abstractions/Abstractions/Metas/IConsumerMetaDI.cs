namespace IziHardGames.EventDrivenDesign.Abstractions
{
    using System;
    using IziHardGames.EventDrivenDesign.Abstractions.Metas;
    public interface IConsumerMetaDI : IConsumerMeta
    {
        Type ServiceType { get; }
    }
}
