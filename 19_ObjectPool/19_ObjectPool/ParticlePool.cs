using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_ObjectPool
{
    class ParticlePool
    {
        private static int POOL_SIZE = 100;
        private Particle[] _particles;

        public ParticlePool()
        {
            _particles = new Particle[POOL_SIZE];
            for (int i = 0; i < POOL_SIZE; i++)
            {
                _particles[i] = new Particle(i.ToString());
            }
        }

        // only initializes new particles if there available slots left
        // note: has to loop through the whole collection every time - O(n) complexity!
        public void Create(double x, double y, double velocityX, double velocityY, int lifetime)
        {
            for (int i = 0; i < POOL_SIZE; i++)
            {
                if (!_particles[i].InUse())
                {
                    _particles[i].Initialize(x, y, velocityX, velocityY, lifetime);
                    return;
                }
            }
        }

        public void Animate()
        {
            for (int i = 0; i < POOL_SIZE; i++)
            {
                _particles[i].Animate();
            }
        }
    }
}
