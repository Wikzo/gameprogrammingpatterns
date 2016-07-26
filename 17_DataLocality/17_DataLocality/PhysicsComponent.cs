using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_DataLocality
{
    class PhysicsComponent
    {
        public void Update()
        {
            double x = new Random().NextDouble() * new Random().Next(100);
            double y = new Random().NextDouble() * new Random().Next(100);

            x += y*new Random().NextDouble();
        }
    }
}
