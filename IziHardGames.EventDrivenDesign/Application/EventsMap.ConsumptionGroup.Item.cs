namespace IziHardGames.EventDrivenDesign.Application
{
    using System;
    using F = System.Func<object, System.Threading.Tasks.Task>;

    public partial class EventsMap
    {
        public partial class ConsumptionGroup
        {
            public class Item
            {
                public F Func { get; }
                public Lazy<object> Target { get; }
                public Item(F func, Func<object> getTarget)
                {
                    Func = func;
                    Target = new Lazy<object>(getTarget);
                }
            }
        }
    }
}