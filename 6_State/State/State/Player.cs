using System;

namespace State
{
    public class Player
    {

        private IPlayerState _state;
        private string _graphics = "";

        public Player(string name)
        {
            this.Name = name;
            _state = new StandingState();
        }

        public void ChangeState(IPlayerState state)
        {
            _state = null; // delete old state (not sure if this works?)

            _state = state;
            _state.EnterState(this);
        }

        public void HandleInput(Input input)
        {
            IPlayerState temp = _state.HandleInput(this, input);

            if (temp != _state)
            {
                _state = null; // delete old state (not sure if this works?)
                _state = temp;
                _state.EnterState(this);
            }

            if (input == Input.Idle)
            {
                _state.TimePass(1);
                Console.WriteLine("Time has passed by 1");

            }
            if (input == Input.TimeFastForward)
            {
                _state.TimePass(10);
                Console.WriteLine("Time has passed by 10");
            }
        }

        public void Update()
        {
            if (_state != null)
                _state.Update(this);

            Console.WriteLine(_graphics);

        }

        public string Name { get; }

        public void SetGraphics(string graphics)
        {
            _graphics = graphics;
        }

        public void SuperBomb()
        {
            Console.WriteLine("*Super Bomb!*");
        }

    }
}