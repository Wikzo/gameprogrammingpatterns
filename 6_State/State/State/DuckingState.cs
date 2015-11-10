using System;

namespace State
{
    public class DuckingState : IPlayerState
    {
        private int _chargeTime;
        private bool _hasExploded;
        private const int MAX_CHARGE = 100;

        public DuckingState()
        {
            _chargeTime = 0;
            _hasExploded = false;
        }

        public IPlayerState HandleInput(Player p, Input input)
        {
            if (input == Input.DPad_Up)
                return new StandingState();

            if (input == Input.JumpButton_Down)
                return new Jumping();

            return this;
        }


        public void Update(Player p)
        {
            if (_hasExploded)
                return;

            _chargeTime++;

            Console.Write(_chargeTime);
            if (_chargeTime > MAX_CHARGE)
            {
                p.SuperBomb();
                _hasExploded = true;
            }
        }

        public void ExitState(Player p)
        {
            throw new NotImplementedException();
        }

        public void TimePass(int time)
        {
            _chargeTime = time;
        }

        public void EnterState(Player p)
        {
            p.SetGraphics("IMAGE_DUCKING");
        }
    }
}