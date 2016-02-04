using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            UpdateSystem system = new UpdateSystem();

            Entity orc = new Entity("Orc1", system);
            Entity troll = new Entity("Troll2", system);
            Entity wizard = new Entity("Wizard3", system);

            int loop = 0;
            while (loop < 10)
            {
                system.Update(16f);

                if (loop == 3)
                    orc.Disable();

                loop++;
            }
            Console.ReadLine();
        }
    }
}
