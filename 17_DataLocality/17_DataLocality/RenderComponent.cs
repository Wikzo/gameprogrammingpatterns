using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_DataLocality
{
    class RenderComponent : IComponent
    {
        public void Update()
        {
            Random r = new Random();
            int updates = r.Next(0, 100);
            for (int i = 0; i < updates; i++)
            {
                //Console.WriteLine("Rendering...");
                double x = new Random().NextDouble();
                double y = Math.Sqrt(x);
            }
        }
    }
}
