using System;

namespace ByteCode
{
    public class Particle
    {
        private string _name;

        public Particle(string name)
        {
            _name = name;
        }

        public void Spawn()
        {
            Console.WriteLine(string.Format("Spawning {0}", this._name));

        }
    }
}