using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_ObjectPool
{

    struct ParticleState
    {
        public double x;
        public double y;
        public double velocityX;
        public double velocityY;
    }
    class ParticleWithFreeList
    {
        private int _framesLeft;
        private string _name;
        private ParticleState _particleState;
        private ParticleWithFreeList _next;

        public ParticleWithFreeList(string name)
        {
            _framesLeft = 0;
            _name = name;
            _next = null;
        }

        public void Initialize(double x, double y, double velocityX, double velocityY, int lifetime)
        {
            _particleState.x = x;
            _particleState.y = y;
            _particleState.velocityX = velocityX;
            _particleState.velocityY = velocityY;
            _framesLeft = lifetime;
        }

        // some kind of linked list
        public void SetNext(ParticleWithFreeList next)
        {
            _next = next;
        }

        public ParticleWithFreeList GetNext()
        {
            return _next;
        }
        public bool Animate()
        {
            if (!InUse()) return false;

            _particleState.x += _particleState.velocityX;
            _particleState.y += _particleState.velocityY;
            _framesLeft--;

            Console.WriteLine("Animating particle {0} [{1} frames left]", _name, _framesLeft);

            return (_framesLeft == 0);
        }

        public bool InUse()
        {
            return _framesLeft > 0;
        }
    }
}
