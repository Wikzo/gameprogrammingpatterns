using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_DirtyFlag
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphNode rootGraph = new GraphNode(null, "Root");
            GraphNode child1 = new GraphNode(null, "Child1");
            GraphNode child2 = new GraphNode(null, "Child2");
            rootGraph.AddChildNode(child1);
            rootGraph.AddChildNode(child2);




            // physics update frame 1 ----------------------------

            Console.WriteLine("*** Frame 1 ***");
            child2.SetTransform(new Transform(child2.Local.Name)); // simulates some kind of physical force
            
            Console.WriteLine("----- Simple traversal -----");
            rootGraph.SimpleRender(Transform.Origin);

            Console.WriteLine();

            Console.WriteLine("----- Dirty-flag traversal -----");
            rootGraph.DirtyFlagRender(Transform.Origin, rootGraph.Dirty);


            Console.WriteLine();
            Console.WriteLine();




            // physics update frame 2 ----------------------------

            Console.WriteLine("*** Frame 2 ***");
            child1.SetTransform(new Transform(child1.Local.Name)); // simulates some kind of physical force

            Console.WriteLine();

            Console.WriteLine("----- Simple traversal -----");
            rootGraph.SimpleRender(Transform.Origin);

            Console.WriteLine();

            Console.WriteLine("----- Dirty-flag traversal -----");
            rootGraph.DirtyFlagRender(Transform.Origin, rootGraph.Dirty);

            Console.WriteLine();
            Console.WriteLine();



            // physics update frame 3 ----------------------------

            Console.WriteLine("*** Frame 3 ***");
            rootGraph.SetTransform(new Transform(rootGraph.Local.Name)); // simulates some kind of physical force

            Console.WriteLine();

            Console.WriteLine("----- Simple traversal -----");
            rootGraph.SimpleRender(Transform.Origin);

            Console.WriteLine();

            Console.WriteLine("----- Dirty-flag traversal -----");
            rootGraph.DirtyFlagRender(Transform.Origin, rootGraph.Dirty);






            Console.ReadLine();
        }
    }
}
