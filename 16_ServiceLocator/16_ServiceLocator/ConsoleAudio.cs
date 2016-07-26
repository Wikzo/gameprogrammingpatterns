using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_ServiceLocator
{
    class ConsoleAudio : IAudio
    {
        public void PlaySound(int soundID)
        {
            Console.WriteLine("Playing audio {0} using ConsoleAudio", soundID);
        }

        public void StopSound(int soundID)
        {
            Console.WriteLine("Stopping audio {0} using ConsoleAudio", soundID);
        }

        public void StopAllSounds()
        {
            Console.WriteLine("Stopping all audio using ConsoleAudio");
        }
    }
}
