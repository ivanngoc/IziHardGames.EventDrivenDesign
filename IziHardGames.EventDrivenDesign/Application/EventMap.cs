namespace IziHardGames.EventDrivenDesign.Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using IziHardGames.EventDrivenDesign.Application.Metas;
    using static IziHardGames.EventDrivenDesign.Application.EventsMap;

    public partial class EventsMap : Dictionary<Type, ConsumptionGroup>
    {
        public EventsMap(IEnumerable<ConsumerMetaT1> enumerable, IEnumerable<KeyValuePair<Type, ConsumptionGroup>> pairs) : base(pairs.ToDictionary(x => x.Key, x => x.Value))
        {

        }
    }
}