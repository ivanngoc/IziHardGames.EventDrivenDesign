namespace IziHardGames.EventDrivenDesign.Application.Metas
{
    using System;
    using IziHardGames.EventDrivenDesign.Abstractions.Metas;

    public class ConsumerMeta : IConsumerMeta
    {
        public Type ImplementationType { get; private set; }
        public Type EventType { get; private set; }
        public Type IFaceType { get; private set; }
        public ConsumerMeta(Type actulaType, Type eventType, Type iface)
        {
            ImplementationType = actulaType;
            EventType = eventType;
            IFaceType = iface;
        }
    }
}
