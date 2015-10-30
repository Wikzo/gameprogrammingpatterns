using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Player p = new Player("Mario");
            ICommand command = null;

            command = InputHandler.HandleInput();

            if (command != null)
                command.Execute(p);

            Console.ReadKey();
        }
    }
}
