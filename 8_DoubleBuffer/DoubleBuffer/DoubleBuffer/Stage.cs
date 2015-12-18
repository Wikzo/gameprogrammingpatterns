using System;

namespace DoubleBuffer
{
    public class Stage
    {
        private Actor[] _actors;
        private int _numberOfActors = 0;

        public Stage(int numberOfActors)
        {
            _actors = new Actor[numberOfActors];
            _numberOfActors = numberOfActors;
        }

        public void AddActor(Actor a, int index)
        {
            _actors[index] = a;
        }

        public string Update(int frame)
        {
            string slaps = "";
            //slaps = String.Format("\nFrame {0}:\n", frame);
           // Console.WriteLine(String.Format("\n*Updating stage (frame {0}):", frame));
            for (int i = 0; i < _numberOfActors; i++)
            {
                slaps += _actors[i].Update();
            }

            //Console.WriteLine("\n--------Swapping stage--------\n");
            for (int i = 0; i < _numberOfActors; i++)
            {
                _actors[i].Swap();
            }

            return slaps;
        }
    }
}