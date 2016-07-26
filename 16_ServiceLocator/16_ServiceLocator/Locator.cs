using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_ServiceLocator
{
    class Locator
    {
        // can also use the specific type to register services:
        // http://stefanoricciardi.com/2009/09/25/service-locator-pattern-in-csharpa-simple-example/
        // https://github.com/Wikzo/Hagenberg_2015/blob/master/GameArchitecture/EchelonEngine/core/src/net/gustavdahl/echelonengine/systems/ServiceLocator.java

        static Locator() {  Initialize(); }

        private static IAudio _audioService;
        private static NullAudio _nullAudioService;

        public static void Initialize()
        {
            // makes sure there is always an object to return
            // in this case, the null object does nothing but prints out a small debug text

            _nullAudioService = new NullAudio();
            _audioService = _nullAudioService;
        }

        public static IAudio GetAudio()
        {
            // code to externally locate a specific service ...

            Debug.Assert(_audioService != null);
            return _audioService;
        }

        public static void ProvideAudioService(IAudio audioService)
        {
            if (audioService == null)
                _audioService = _nullAudioService;
            else
                _audioService = audioService;
        }

    }
}
