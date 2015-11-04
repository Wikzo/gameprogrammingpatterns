using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Ghost fastGhost = new Ghost(5, 10);
            Spawner Spawner = new Spawner(fastGhost);

            List<Ghost> fastGhosts = new List<Ghost>();

            for (int i = 0; i < 10; i++)
            {
                fastGhosts.Add((Ghost) Spawner.SpawnMonster());

                fastGhosts[i].PrintStats();

            }

            Console.ReadLine();

        }
    }
}
