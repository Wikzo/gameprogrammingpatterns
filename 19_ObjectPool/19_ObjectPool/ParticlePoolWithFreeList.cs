using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_ObjectPool
{
    class ParticlePoolWithFreeList
    {
        private static int POOL_SIZE = 100;

        private ParticleWithFreeList _firstAvilable;
        private ParticleWithFreeList[] _particlesFreeList;

        public ParticlePoolWithFreeList()
        {
            // these initialization loops are not totally correct (according to the book)
            // since I cannot use pointers in C#

            _particlesFreeList = new ParticleWithFreeList[POOL_SIZE];

            for (int i = 0; i < POOL_SIZE; i++)
            {
                _particlesFreeList[i] = new ParticleWithFreeList(i.ToString());
            }

            for (int i = 0; i < POOL_SIZE; i++)
            {
                _particlesFreeList[i].SetNext(_particlesFreeList[i + 1]);
            }

            _firstAvilable = _particlesFreeList[0];
            _particlesFreeList[POOL_SIZE - 1].SetNext(null);
        }

        // O(1) complexity, since there is no big loop to go through
        public void Create(double x, double y, double velocityX, double velocityY, int lifetime)
        {
            // Make sure the pool isn't full
            Debug.Assert(_firstAvilable != null);

            // remove if from the avilable list
            ParticleWithFreeList newParticle = _firstAvilable;
            _firstAvilable = newParticle.GetNext();

            newParticle.Initialize(x,y,velocityX,velocityY, lifetime);
        }

        public void Animate()
        {
            for (int i = 0; i < POOL_SIZE; i++)
            {
                _particlesFreeList[i].Animate();
            }
        }
    }
}
