using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_ServiceLocator
{
    interface IAudio
    {
        void PlaySound(int soundID);
        void StopSound(int soundID);
        void StopAllSounds();
    }
}
