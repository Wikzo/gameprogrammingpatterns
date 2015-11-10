using System;

namespace State
{
    public class StandingState : IPlayerState
    {
        public IPlayerState HandleInput(Player p, Input input)
        {
            if (input == Input.JumpButton_Down)
               return new Jumping();
            if (input == Input.DPad_Down)
                return new DuckingState();

            return this;

        }

        public void Update(Player p)
        {
            Console.WriteLine("Standing...");
        }

        public void TimePass(int time)
        {
        }

        public string Graphics { get { return "IMAGE_STANDING"; } }

    }
}