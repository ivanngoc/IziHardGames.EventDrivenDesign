namespace IziHardGames.EventDrivenDesign.Application.Metas
{
    using System;
    using IziHardGames.EventDrivenDesign.Abstractions;
    public readonly struct ConsumerMetaT1 : IConsumerMetaDI
    {
        public readonly ConsumerMeta meta;
        public readonly Type registeredAs;

        public ConsumerMetaT1(ConsumerMeta meta, Type registeredAs)
        {
            this.registeredAs = registeredAs;
            this.meta = meta;
        }

        public Type ServiceType => registeredAs;
        public Type ImplementationType { get => meta.ImplementationType; }
        public Type EventType { get => meta.EventType; }
        public Type IFaceType { get => meta.IFaceType; }
    }
}