using System;

namespace DoubleBuffer
{
    public class Stage
    {
        private const int NUM_ACTORS = 3;
        private Actor[] _actors = new Actor[NUM_ACTORS];

        public void AddActor(Actor a, int index)
        {
            _actors[index] = a;
        }

        public void Update()
        {
            Console.WriteLine("\n--------Updating stage--------\n");
            for (int i = 0; i < NUM_ACTORS; i++)
            {
                _actors[i].Update();
                _actors[i].Reset();
            }
        }
    }
}