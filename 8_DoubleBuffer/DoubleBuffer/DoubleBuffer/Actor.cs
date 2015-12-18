using System;

namespace DoubleBuffer
{
    public abstract class Actor
    {
        public bool CurrentSlapped { get; private set; }
        public bool NextSlapped { get; private set; }

        public string Name { get; }

        public Actor(String name)
        {
            CurrentSlapped = false;
            Name = name;
        }

        public abstract string Update();

        public void Swap() // buffer like in graphics: one we see and one that is updated in the background
        {
            CurrentSlapped = NextSlapped; // swap the buffer

            NextSlapped = false; // clear the new 'next' buffer
        }

        public string Slap(Actor slapper)
        {
            NextSlapped = true;
            return String.Format("{0} was slapped by {1}\n", Name, slapper.Name);
        }

        public string Slap(string name)
        {
            return Slap(new Comedian(name));
        }


    }
}