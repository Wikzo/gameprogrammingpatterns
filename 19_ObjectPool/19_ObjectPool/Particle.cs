using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_ObjectPool
{
    class Particle
    {
        private int _framesLeft;
        private double _x, _y;
        private double _velocityX, _velocityY;
        private string _name;

        public Particle(string name)
        {
            _framesLeft = 0;
            _name = name;
        }

        public void Initialize(double x, double y, double velocityX, double velocityY, int lifetime)
        {
            _x = x;
            _y = y;
            _velocityX = velocityX;
            _velocityY = velocityY;
            _framesLeft = lifetime;
        }

        public void Animate()
        {
            if (!InUse()) return;

            _x += _velocityX;
            _y += _velocityY;

            Console.WriteLine("Animating particle {0} [{1} frames left]", _name, _framesLeft);
            _framesLeft--;
        }

        public bool InUse()
        {
            return _framesLeft > 0;
        }
    }
}
