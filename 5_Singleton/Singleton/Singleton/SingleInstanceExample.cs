using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class SingleInstanceExample
    {
        private static bool _instantated = false;

        public SingleInstanceExample()
        {
            // Assert: http://www.dotnetperls.com/assert
            Debug.Assert(!_instantated, "SingleInstanceExample has already been instantiated. Can only have one instance!");
            _instantated = true;
        }
    }
}
