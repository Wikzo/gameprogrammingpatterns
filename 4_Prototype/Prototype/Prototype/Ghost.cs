using System;

namespace Prototype
{
    public class Ghost : Monster
    {
        private float speed;
        private int health;

        public Ghost(string name, int health, float speed)
        {
            this._name = name;
            this.health = health;
            this.speed = speed;
        }

        public Ghost()
        {
            this._name = "DefaultName";
        }

        public override Monster Clone()
        {
            return new Ghost(this._name, this.health, this.speed);
        }

        public void PrintStats()
        {
            Console.WriteLine("Name: " + this._name + "; Speed: " + this.speed + "; Health: " + this.health);
        }

        // ---------------------------------
        // using callbacks:
        public Monster SpawnGhost()
        {
            return new Ghost(this._name, this.health, this.speed);
        }
    }
}