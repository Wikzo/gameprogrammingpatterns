namespace State
{
    public interface IPlayerState
    {
        IPlayerState HandleInput(Player p, Input input);
        void Update(Player p);
        void TimePass(int time);
        string Graphics { get;}
    }
}