namespace IziHardGames.EventDrivenDesign.Abstractions.Metas
{
    using System;

    public interface IConsumerMeta
    {
        Type ImplementationType { get; }
        Type EventType { get; }
        /// <summary>
        /// <see cref="IConsumerAsync{T}"/>
        /// </summary>
        Type IFaceType { get; }
    }
}
