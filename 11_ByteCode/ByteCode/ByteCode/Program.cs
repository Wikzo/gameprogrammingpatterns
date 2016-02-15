using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteCode
{
    class Program
    {
        static void Main(string[] args)
        {
            VM virtualMachine = new VM();

            char[] byteCode = new[]
            {
                // set wizard 0's health to 100
                (char)Instructions.INST_LITERAL,
                (char)0, // select wizard 0
                (char)Instructions.INST_LITERAL,
                (char)100, // set health to 100
                (char)Instructions.INST_SET_HEALTH,

                // play sound 2
                (char)Instructions.INST_LITERAL,
                (char)2,
                (char)Instructions.INST_PLAY_SOUND
            };

            virtualMachine.Interpret(byteCode, byteCode.Length);

            Console.ReadLine();
        }
    }
}
