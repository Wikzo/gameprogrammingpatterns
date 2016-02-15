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
            {(char)Instructions.INST_SET_HEALTH, (char)Instructions.INST_PLAY_SOUND, (char)Instructions.INST_SET_WISDOM};
            virtualMachine.Interpret(byteCode, byteCode.Length);

            Console.ReadLine();
        }
    }
}
