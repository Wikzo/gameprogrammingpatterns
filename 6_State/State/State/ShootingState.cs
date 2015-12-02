using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    class ShootingState : IPlayerState
    {
        private int _shootingTime;
        private const int MAX_SHOOTING_TIME = 2;

        private Stack<IPlayerState> _stateStack = new Stack<IPlayerState>();

        public ShootingState(IPlayerState previousState)
        {
            _stateStack.Push(previousState);
            _stateStack.Push(this);

            IPlayerState[] arr = _stateStack.ToArray();

            string stackItems = "";
            foreach (IPlayerState p in arr)
                stackItems += p.ToString()  + "; ";

            Console.WriteLine(string.Format("Shooting stack (size: {0}): {1}", arr.Length, stackItems));
        }

        public IPlayerState HandleInput(Player p, Input input)
        {
            return this;
        }

        public void Update(Player p)
        {
            if (_shootingTime >= MAX_SHOOTING_TIME)
            {
                Console.WriteLine("Shooting done... Going back to previous state: " + _stateStack.Peek());
                p.ChangeState(_stateStack.Pop());
            }
        }

        public void EnterState(Player p)
        {
            Console.WriteLine("Popping: " + _stateStack.Pop());
            p.SetGraphics("SHOOTING_IMAGE");
            Console.ForegroundColor = ConsoleColor.DarkGray;
        }

        public void ExitState(Player p)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void TimePass(int time)
        {
            _shootingTime += time;
        }
    }
}
