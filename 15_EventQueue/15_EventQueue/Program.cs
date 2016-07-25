using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_EventQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();

            menu.OnStart(1);
            menu.OnStart(2);
            menu.OnStart(3);
            Audio.Update();
            menu.OnDeselect();
            Audio.Update();
            Audio.Update();
            menu.OnExit();
            Audio.Update();
            
            Console.ReadLine();
        }
    }
}
