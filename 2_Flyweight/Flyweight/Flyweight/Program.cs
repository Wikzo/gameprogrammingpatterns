using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight
{
    class Program
    {
        static void Main(string[] args)
        {
            World w = new World();

            w.GenerateTerrain();

            for (int x = 0; x < World.Width; x++)
            {
                for (int y = 0; y < World.Height; y++)
                {
                    Console.WriteLine(w.GetTile(x, y).GetTerrainType());
                }
            }

            Console.ReadKey();
        }
    }
}
