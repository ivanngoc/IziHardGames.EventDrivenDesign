namespace IziHardGames.EventDrivenDesign.Abstractions
{
    public interface IRouterT1 : IRouter
    {
        void Route<TEvent>(TEvent e);
    }
}
