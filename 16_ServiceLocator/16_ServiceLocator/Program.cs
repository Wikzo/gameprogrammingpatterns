using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_ServiceLocator
{
    class Program
    {
        static void Main(string[] args)
        {
            // create concrete audio class and inject it into the service provider (dependency injection)
            ConsoleAudio consoleAudio = new ConsoleAudio();
            Locator.ProvideAudioService(consoleAudio);
            Locator.GetAudio().PlaySound(1); // no awareness of the concrete ConsoleAudio class

            Console.WriteLine();

            // can use null object
            Locator.ProvideAudioService(null);
            Locator.GetAudio().PlaySound(2);

            Console.WriteLine();

            // can change implementation details during runtime, e.g. to a logging audio service
            LoggedAudio loggedAudio = new LoggedAudio(consoleAudio);
            Locator.ProvideAudioService(loggedAudio);
            Locator.GetAudio().PlaySound(3);

            Console.WriteLine();

            // can tempoarily disable audio playback (but keep the logging) using a null object
            loggedAudio = new LoggedAudio(null);
            Locator.ProvideAudioService(loggedAudio);
            Locator.GetAudio().PlaySound(4);

            Console.ReadLine();
        }
    }
}
