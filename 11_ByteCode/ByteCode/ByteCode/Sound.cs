using System;

namespace ByteCode
{
    public class Sound
    {
        private string _name;

        public Sound(string name)
        {
            _name = name;
        }

        public void Play()
        {
            Console.WriteLine(string.Format("Playing sound {0}", this._name));
        }
    }
}