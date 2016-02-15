using System;
using System.Diagnostics;

namespace ByteCode
{
    public enum Instructions
    {
        INST_SET_HEALTH = 0x00,
        INST_SET_WISDOM = 0x01,
        INST_SET_AGILITY = 0x02,
        INST_PLAY_SOUND = 0x03,
        INST_SPAWN_PARTICLES = 0x04,
        INST_LITERAL = 0x05 // used to give any litteral number
    }

    public class VM
    {
        private static int MAX_STACK = 128;
        private int _stackIndex;
        private int[] _stack = new int[MAX_STACK];

        private Wizard[] _wizards;
        private Sound[] _sounds;
        private Particle[] _particles;

        public VM()
        {
            Wizard w1 = new Wizard("FireWizard_0");
            Wizard w2 = new Wizard("WaterWizard_1");
            _wizards = new Wizard[] {w1, w2};

            _sounds = new Sound[] {
                new Sound("EarthQuake_0"),
                new Sound("MachineGun_1"),
                new Sound("MagicBurst_2"),
                new Sound("Waterfall_3")};

            _particles = new Particle[]
            {
                new Particle("ExplosionParticle_0"),
                new Particle("LavaParticle_1"),
                new Particle("WaterBubbleParticle_2")
            };
        }

        public void Interpret(char[] byteCode, int size)
        {
            for (int i = 0; i < size; i++)
            {
                char instruction = byteCode[i];

                int amount;
                int wizard;
                switch (instruction)
                {
                    // read and push the next byte from the byte code
                    case (char)Instructions.INST_LITERAL:
                        int value = byteCode[++i];
                        Push(value);
                        break;

                    case (char)Instructions.INST_SET_HEALTH:
                        amount = Pop();
                        wizard = Pop();

                        SetHealth(wizard, amount);
                        break;

                    case (char)Instructions.INST_SET_WISDOM:
                        amount = Pop();
                        wizard = Pop();

                        SetWisdom(wizard, amount);
                        break;

                    case (char)Instructions.INST_SET_AGILITY:
                        amount = Pop();
                        wizard = Pop();

                        SetAgility(wizard, amount);
                        break;

                    case (char)Instructions.INST_PLAY_SOUND:
                        PlaySound(Pop());
                        break;

                    case (char)Instructions.INST_SPAWN_PARTICLES:
                        SpawnParticles(Pop());
                        break;
                }
            }
        }

        private void Push(int value)
        {
            Debug.Assert(_stackIndex < MAX_STACK);
            _stack[_stackIndex++] = value;
        }

        private int Pop()
        {
            Debug.Assert(_stackIndex > 0);
            return _stack[--_stackIndex];
        }

        private void SetHealth(int player, int amount)
        {
            _wizards[player].Health = amount;
        }

        private void SetWisdom(int player, int amount)
        {
            _wizards[player].Wisdom = amount;
        }

        private void SetAgility(int player, int amount)
        {
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