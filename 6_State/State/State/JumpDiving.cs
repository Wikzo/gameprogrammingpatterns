namespace State
{
    public class JumpDiving : IPlayerState
    {
        private int _airTime;
        private const int MAX_AIR_TIME = 5;

        public JumpDiving()
        {
            _airTime = 0;
        }

        public IPlayerState HandleInput(Player p, Input input)
        {
            return this;
        }

        public void Update(Player p)
        {
            _airTime++;

            if (_airTime > MAX_AIR_TIME)
                p.ChangeState(new StandingState());
        }

        public void TimePass(int time)
        {
            _airTime += time;
        }

        public string Graphics { get { return "IMAGE_JUMPDIVING"; } }

    }
}