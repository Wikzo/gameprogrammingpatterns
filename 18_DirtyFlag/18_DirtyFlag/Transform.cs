using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_DirtyFlag
{
    class Transform
    {
        public static Transform Origin; // identity matrix without translation/rotation/scaling

        public Transform Combine(Transform other)
        {
            // Do some calculations to combine all of the local transforms along its parent
            // this will get the world transform of this object

            return new Transform();
        }
    }
}
