namespace State
{
    public class Jumping : IPlayerState
    {
        private int _airTime;
        private const int MAX_AIR_TIME = 5;

        public Jumping()
        {
            _airTime = 0;
        }

        public IPlayerState HandleInput(Player p, Input input)
        {
            if (input == Input.JumpButton_Down)
                return new JumpDiving();

            if (input == Input.DPad_Down)
                return new GroundPound();

            return this;
        }

        public void Update(Player p)
        {
            _airTime++;

            if (_airTime > MAX_AIR_TIME)
                p.ChangeState(new StandingState());
        }

        public void EnterState(Player p)
        {
            p.SetGraphics("IMAGE_JUMPING");
        }

        public void ExitState(Player p)
        {
            throw new System.NotImplementedException();
        }

        public void TimePass(int time)
        {
            _airTime += time;
        }


    }
}