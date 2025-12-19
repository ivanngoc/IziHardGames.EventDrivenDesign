using System;

namespace IziHardGames.EventDrivenDesign.Application.Metas
{
    public class ConsumerMeta
    {
        public Type ActulaType { get; private set; }
        public Type EventType { get; private set; }
        public Type IFace { get; private set; }
        public ConsumerMeta(Type actulaType, Type eventType, Type iface)
        {
            ActulaType = actulaType;
            EventType = eventType;
            IFace = iface;
        }
    }
}
