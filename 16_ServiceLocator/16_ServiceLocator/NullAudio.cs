using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_ServiceLocator
{
    class NullAudio : IAudio
    {
        public void PlaySound(int soundID)
        {
            Console.WriteLine("Null object used");
        }

        public void StopSound(int soundID)
        {
            Console.WriteLine("Null object used");
        }

        public void StopAllSounds()
        {
            Console.WriteLine("Null object used");
        }
    }
}
