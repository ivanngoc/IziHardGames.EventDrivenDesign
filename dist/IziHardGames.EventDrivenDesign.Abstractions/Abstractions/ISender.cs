namespace IziHardGames.EventDrivenDesign.Abstractions
{
    public interface ISender
    {
        void Send<TMsg, TTarget>(TMsg msg);
    }
}
