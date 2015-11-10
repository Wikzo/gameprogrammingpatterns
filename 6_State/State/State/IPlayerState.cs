namespace State
{
    public interface IPlayerState
    {
        IPlayerState HandleInput(Player p, Input input);
        void Update(Player p);
        void EnterState(Player p);
        void ExitState(Player p);
        void TimePass(int time);
    }
}