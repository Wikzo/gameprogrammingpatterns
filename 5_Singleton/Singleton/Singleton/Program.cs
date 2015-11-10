using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Tip: try avoid using singletons in general
// Singletons have two purposes: giving only ONE instance
// and giving GLOBAL access.
// Both things can be accomplished in other ways, e.g., via the Service Locator pattern

// Problems with singletons:
// 1) Global variables makes it harder to reason about code. We have no idea who changed the variables and where.
// 2) They encourage coupling.
// 3) Not concurrency-friendly. Multiple threads can use the singleton fields. This can lead to deadlocks and race conditions due to synchronization bugs.

// Solutions:
// 1) Often singletons are used as manager classes, e.g. GameManager, LogManager, SoundManager, etc.
//    But often times they are not really needed, since the data/behaviour can be on the class itself (e.g., Bullet).
// 2) Can provide convient access to an instance by passing it in ("dependency injection"),
//    using data from a base class,
//    or utilizing a class that is already global (e.g. World or Game) and make fields to instances.
//    OR use Service Locators!

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSystemSingleton1.Instance().File1 = 2;

            SingleInstanceExample instance1 = new SingleInstanceExample();
            SingleInstanceExample instance2 = new SingleInstanceExample(); // <-- can only have one instance!

            Console.ReadKey();
        }
    }
}
