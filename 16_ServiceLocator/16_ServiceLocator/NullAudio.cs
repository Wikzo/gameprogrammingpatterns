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
            Console.WriteLine("NO AUDIO - Null object used to play audio");
        }

        public void StopSound(int soundID)
        {
            Console.WriteLine("NO AUDIO - Null object used to stop audio");
        }

        public void StopAllSounds()
        {
            Console.WriteLine("NO AUDIO - Null object used to stop all sounds");
        }
    }
}
