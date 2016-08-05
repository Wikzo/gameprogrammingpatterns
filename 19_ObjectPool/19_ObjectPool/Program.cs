using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_ObjectPool
{
    class Program
    {
        static void Main(string[] args)
        {
            ParticlePool particlePool = new ParticlePool();

            particlePool.Create(5,1,3,2,1);
            particlePool.Create(5,1,3,2,6);
            particlePool.Create(5,1,3,2,2);

            particlePool.Animate();
            particlePool.Animate();
            particlePool.Animate();
            particlePool.Animate();

            Console.ReadLine();

            // (I didn't test it with the ParticlePoolWithFreeList ...)
        }
    }
}
