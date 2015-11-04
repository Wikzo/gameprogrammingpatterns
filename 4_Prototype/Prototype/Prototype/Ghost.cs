using System;

namespace Prototype
{
    public class Ghost : Monster
    {
        private float speed;
        private int health;

        public Ghost(int health, float speed)
        {
            this.health = health;
            this.speed = speed;
        }

        public override Monster Clone()
        {
            return new Ghost(this.health, this.speed);
        }

        public void PrintStats()
        {
            Console.WriteLine("Speed: " + this.speed + "; Health: " + this.health);
        }
    }
}