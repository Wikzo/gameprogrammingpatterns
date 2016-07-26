using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_DataLocality
{
    class AIComponent : IComponent
    {
        public void Update()
        {
            Random random = new Random();
            int r = random.Next(1, 1000);
            int r2 = random.Next(1, 1000);
            double r3 = random.NextDouble()*r;

            r = r*r2;
            r3 /= r2*Math.Pow(r3, r3)*r;

            r3 = Math.Sqrt(r3);
        }
    }
}
