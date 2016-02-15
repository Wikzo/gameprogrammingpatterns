using System;

namespace ByteCode
{
    public class Wizard
    {
        private int _health;
        private int _wisdom;
        private int _agility;
        private string _name;

        public Wizard(string name)
        {
            _name = name;
        }

        public int Health
        {
            get { return _health; }
            set
            {
                _health = value; Console.WriteLine(string.Format("{0}'s health: {1}", this._name, this.Health));
            }
        }

        public int Wisdom
        {
            get { return _wisdom; }
            set
            {
                _wisdom = value;
                Console.WriteLine(string.Format("{0}'s wisdom: {1}", this._name, this.Wisdom));
            }
        }

        public int Agility
        {
            get { return _agility; }
            set
            {
                _agility = value;
                Console.WriteLine(string.Format("{0}'s agility: {1}", this._name, this.Agility));
            }
        }
    }
}