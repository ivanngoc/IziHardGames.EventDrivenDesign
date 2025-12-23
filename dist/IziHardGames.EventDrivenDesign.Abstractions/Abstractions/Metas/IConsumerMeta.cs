using System;

namespace IziHardGames.EventDrivenDesign.Abstractions.Metas
{
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
