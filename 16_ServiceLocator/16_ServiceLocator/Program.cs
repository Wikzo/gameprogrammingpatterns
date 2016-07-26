using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_ServiceLocator
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleAudio consoleAudio = new ConsoleAudio();
            Locator.Provide(consoleAudio);

            Locator.GetAudio().PlaySound(1);

            Console.ReadLine();
        }
    }
}
