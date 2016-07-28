using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_DirtyFlag
{
    class Transform
    {
        public string Name;

        public Transform(string name)
        {
            Name = name;
        }

        public static Transform Origin = new Transform("Origin"); // identity matrix without translation/rotation/scaling

        public Transform Combine_ExpensiveCalucations(Transform other)
        {
            // Do some expensive calculations to combine all of the local transforms along its parent
            // This will get the world transform of this object

            Console.WriteLine("Doing heavy matrix calculations with {0}", this.Name);

            return this;
        }
    }
}
