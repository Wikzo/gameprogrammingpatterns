using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Wizard[] wizards;
            Sound[] sounds;
            Particle[] particles;
            CreateEntities(out wizards, out sounds, out particles);

            VM virtualMachine = new VM(wizards, sounds, particles);
            char[] byteCode = CreateCommands();

            virtualMachine.Interpret(byteCode, byteCode.Length);

            Console.ReadLine();
        }

        private static char[] CreateCommands()
        {
            char[] byteCode = new[]
                        {
                // set wizard 0's health to 5
                (char)Instructions.LITERAL,
                (char)0,
                (char)Instructions.LITERAL,
                (char)5,
                (char)Instructions.SET_HEALTH,

                // set wizard 1's health to 10
                (char)Instructions.LITERAL,
                (char)1,
                (char)Instructions.LITERAL,
                (char)10,
                (char)Instructions.SET_HEALTH,

                // play sound 2
                (char)Instructions.LITERAL,
                (char)2,
                (char)Instructions.PLAY_SOUND,

                // multiply wizard 0's and wizard 1's health and add 25
                // 5 * 10 + 25 = 75
                (char)Instructions.LITERAL,
                (char)0,
                (char)Instructions.LITERAL,
                (char)0,
                (char)Instructions.GET_HEALTH,
                (char)Instructions.LITERAL,
                (char)1,
                (char)Instructions.GET_HEALTH,
                (char)Instructions.MULTIPLY,
                (char)Instructions.LITERAL,
                (char)25,
                (char)Instructions.ADD,
                (char)Instructions.SET_HEALTH
            };
            return byteCode;
        }

        private static void CreateEntities(out Wizard[] wizards, out Sound[] sounds, out Particle[] particles)
        {
            wizards = new Wizard[]
            {
                new Wizard("FireWizard_0"),
                new Wizard("WaterWizard_1")
            };

            sounds = new Sound[] {
                new Sound("EarthQuake_0"),
                new Sound("MachineGun_1"),
                new Sound("MagicBurst_2"),
                new Sound("Waterfall_3")};

            particles = new Particle[]
            {
                new Particle("ExplosionParticle_0"),
                new Particle("LavaParticle_1"),
                new Particle("WaterBubbleParticle_2")
            };
        }
    }
}
