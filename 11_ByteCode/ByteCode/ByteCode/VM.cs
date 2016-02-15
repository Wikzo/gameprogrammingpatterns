using System;

namespace ByteCode
{
    public enum Instructions
    {
        INST_SET_HEALTH = 0x00,
        INST_SET_WISDOM = 0x01,
        INST_SET_AGILITY = 0x02,
        INST_PLAY_SOUND = 0x03,
        INST_SPAWN_PARTICLES = 0x04,
        INST_LITERAL = 0x05
    }

    public class VM
    {
        private Wizard[] _wizards;
        private Sound[] _sounds;
        private Particle[] _particles;

        public VM()
        {
            Wizard w1 = new Wizard();
            Wizard w2 = new Wizard();
            _wizards = new Wizard[] {w1, w2};

            _sounds = new Sound[] {new Sound(), new Sound()};
            _particles = new Particle[] {new Particle(), new Particle()};
        }

        public void Interpret(char[] bytecode, int size)
        {
            for (int i = 0; i < size; i++)
            {
                char instruction = bytecode[i];

                switch (instruction)
                {
                    case (char)Instructions.INST_SET_HEALTH:
                        SetHealth(0,100);
                        break;

                    case (char)Instructions.INST_SET_WISDOM:
                        SetWisdom(0, 100);
                        break;

                    case (char)Instructions.INST_SET_AGILITY:
                        SetAgility(0, 100);
                        break;

                    case (char)Instructions.INST_PLAY_SOUND:
                        PlaySound(0);
                        break;

                    case (char)Instructions.INST_SPAWN_PARTICLES:
                        SpawnParticles(0);
                        break;
                }
            }
        }

        private void SetHealth(int player, int amount)
        {
            Console.WriteLine("Setting health");

            _wizards[player].Health = amount;
        }

        private void SetWisdom(int player, int amount)
        {
            Console.WriteLine("Setting wisdom");

            _wizards[player].Wisdom = amount;
        }

        private void SetAgility(int player, int amount)
        {
            Console.WriteLine("Setting agility");

            _wizards[player].Agility = amount;
        }

        private void PlaySound(int soundID)
        {
            _sounds[soundID].Play();
        }

        private void SpawnParticles(int particleType)
        {
            _particles[particleType].Spawn();
        }
    }
}