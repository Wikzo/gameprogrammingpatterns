using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_ServiceLocator
{
    class Locator
    {
        private static IAudio _audioService;

        public static IAudio GetAudio() { return _audioService; }
        public static void Provide(IAudio audio) { _audioService = audio; }


    }
}
