using System;

namespace DoubleBuffer
{
    public abstract class Actor
    {
        public bool Slapped { get; private set; }

        public string Name { get; }

        public Actor(String name)
        {
            Slapped = false;
            Name = name;
        }

        public abstract void Update();

        public void Reset()
        {
            Slapped = false;
        }

        protected internal void Slap(Actor slapper)
        {
            Slapped = true;
            Console.WriteLine(String.Format("{0} was slapped by {1}", Name, slapper.Name));
        }

        protected internal void Slap()
        {
            Slap(new Comedian("Somebody secret"));
        }


    }
}