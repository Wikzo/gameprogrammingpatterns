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
            _state = state;
            _graphics = state.Graphics;
        }

        public void HandleInput(Input input)
        {
            if (_state != null)
            {
                IPlayerState temp = _state.HandleInput(this, input);
                _state = null; // delete old state (not sure if this works?)

                _state = temp;
                _graphics = _state.Graphics;
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

        public void SuperBomb()
        {
            Console.WriteLine("*Super Bomb!*");
        }

        public void Jump()
        {
            Console.WriteLine(Name + " is jumping!");

        }

        public void Crouch()
        {
            Console.WriteLine("*Showing crouching grahic*");


        }

        public void Reload()
        {
            Console.WriteLine(Name + " is reloading!");


        }

        public void Shoot()
        {
            Console.WriteLine(Name + " is shooting!");


        }
    }
}