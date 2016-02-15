using System;
using System.Diagnostics;

namespace ByteCode
{
    public enum Instructions
    {
        SET_HEALTH = 0x00,
        SET_WISDOM = 0x01,
        SET_AGILITY = 0x02,
        GET_HEALTH = 0x03,
        GET_WISDOM = 0x04,
        GET_AGILITY = 0x05,

        PLAY_SOUND = 0x06,
        SPAWN_PARTICLES = 0x07,
        
        ADD = 0x08,
        MULTIPLY = 0x09,
        DIVIDE = 0x10,

        LITERAL = 0x11 // used to give any literal number
    }

    public class VM
    {
        private static int MAX_STACK = 128;
        private int _stackIndex;
        private int[] _stack = new int[MAX_STACK];

        private Wizard[] _wizards;
        private Sound[] _sounds;
        private Particle[] _particles;

        public VM(Wizard[] w, Sound[] s, Particle[] p)
        {
            _wizards = w;
            _sounds = s;
            _particles = p;
        }

        public void Interpret(char[] byteCode, int size)
        {
            for (int i = 0; i < size; i++)
            {
                char instruction = byteCode[i];

                int amount;
                int wizardIndex;
                switch (instruction)
                {
                    // read and push the next byte from the byte code
                    case (char)Instructions.LITERAL:
                        int value = byteCode[++i];
                        Push(value);
                        break;

                    case (char)Instructions.ADD:
                        int b_add = Pop();
                        int a_add = Pop();
                        Push(a_add + b_add);
                        break;

                    case (char)Instructions.MULTIPLY:
                        int b_multiply = Pop();
                        int a_multiply = Pop();
                        Push(a_multiply * b_multiply);
                        break;

                    case (char)Instructions.DIVIDE:
                        int b_divide = Pop();
                        int a_divide = Pop();
                        Push(a_divide / b_divide);
                        break;

                    case (char)Instructions.SET_HEALTH:
                        amount = Pop();
                        wizardIndex = Pop();

                        _wizards[wizardIndex].Health = amount;
                        break;

                    case (char)Instructions.SET_WISDOM:
                        amount = Pop();
                        wizardIndex = Pop();

                        _wizards[wizardIndex].Wisdom = amount;

                        break;

                    case (char)Instructions.SET_AGILITY:
                        amount = Pop();
                        wizardIndex = Pop();

                        _wizards[wizardIndex].Agility = amount;
                        break;

                    case (char)Instructions.GET_HEALTH:
                        wizardIndex = Pop();

                        Push(_wizards[wizardIndex].Health);
                        break;

                    case(char)Instructions.GET_WISDOM:
                        wizardIndex = Pop();

                        Push(_wizards[wizardIndex].Wisdom);
                        break;

                    case (char)Instructions.GET_AGILITY:
                        wizardIndex = Pop();

                        Push(_wizards[wizardIndex].Agility);
                        break;

                    case (char)Instructions.PLAY_SOUND:
                        PlaySound(Pop());
                        break;

                    case (char)Instructions.SPAWN_PARTICLES:
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