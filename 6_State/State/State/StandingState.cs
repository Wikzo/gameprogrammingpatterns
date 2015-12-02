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
            if (input == Input.Shooting)
                return new ShootingState(this);

            return this;

        }

        public void Update(Player p)
        {
            Console.WriteLine("Standing...");
        }

        public void ExitState(Player p)
        {
        }

        public void TimePass(int time)
        {
        }

        public void EnterState(Player p)
        {
            Random r = new Random();
            int a = r.Next(10);
            p.SetGraphics("IMAGE_STANDING " + a);
        }

    }
}