using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_EventQueue
{

    
    class Menu
    {
        private const int SOUND_START = 7;
        private const int SOUND_DESELECT = 5;
        private const int SOUND_EXIT = 3;

        public void OnStart()
        {
            Console.WriteLine("*Event: Menu button START pressed*");
            Audio.PlaySound(SOUND_START, 10);
        }

        public void OnDeselect()
        {
            Console.WriteLine("*Event: Menu button DESELECT pressed*");
            Audio.PlaySound(SOUND_DESELECT, 5);
        }

        public void OnExit()
        {
            Console.WriteLine("*Event: Menu button EXIT pressed*");
            Audio.PlaySound(SOUND_EXIT, 3);
        }
    }
}
