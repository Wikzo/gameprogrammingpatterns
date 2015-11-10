using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    class InputHandler
    {
        public static Input HandleInput()
        {
            Console.WriteLine("Possible input: d_down, d_up, jump_down, jump_up, idle, time\n>");

            String input = Console.ReadLine();

            Console.WriteLine("\n");

            if (input.ToLower() == "d_down") return Input.DPad_Down;
            if (input.ToLower() == "d_up") return Input.DPad_Up;
            if (input.ToLower() == "jump_down") return Input.JumpButton_Down;
            if (input.ToLower() == "jump_up") return Input.JumpButton_Up;
            if (input.ToLower() == "idle") return Input.Idle;
            if (input.ToLower() == "time") return Input.TimeFastForward;

            Console.WriteLine("Invalid input! Try again...\n");

            return Input.Invalid;
        }
    }
}
