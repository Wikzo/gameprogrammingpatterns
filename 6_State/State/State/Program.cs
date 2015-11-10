using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            Player p = new Player("Mario");
            Input input = Input.Idle;

            bool quit = false;
            while (!quit)
            {

                //Console.WriteLine(input);

                p.Update();

                input = InputHandler.HandleInput();
                p.HandleInput(input);

                if (input == Input.Quit)
                    quit = true;
            }
        }
    }
}
