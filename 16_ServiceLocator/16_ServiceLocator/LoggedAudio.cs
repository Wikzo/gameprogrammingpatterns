using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_ServiceLocator
{
    class LoggedAudio : IAudio
    {
        private IAudio _wrapped;

        public LoggedAudio(IAudio wrapped)
        {
            if (wrapped == null)
                _wrapped = new NullAudio();
            else
                _wrapped = wrapped;
        }

        public void PlaySound(int soundID)
        {
            Log("Play sound " + soundID);
            _wrapped.PlaySound(soundID);
        }

        public void StopSound(int soundID)
        {
            Log("Stop sound " + soundID);
            _wrapped.StopSound(soundID);
        }

        public void StopAllSounds()
        {
            Log("Stop all sounds");
            _wrapped.StopAllSounds();
        }

        private void Log(string text)
        {
            Console.WriteLine("[AudioLog: {0}]", text);
        }
    }
}
