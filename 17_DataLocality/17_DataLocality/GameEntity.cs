using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_DataLocality
{
    class GameEntity
    {
        public PhysicsComponent Physics;
        public AIComponent Ai;
        public RenderComponent Render;

        // for this to work, the components should be passed as pointers
        // this is NOT possible in C#
        // can use pass by reference or unsafe context ... but still not the same as in C++
        public GameEntity(PhysicsComponent physics, AIComponent ai, RenderComponent render)
        {
            Physics = physics;
            Ai = ai;
            Render = render;
        }
    }
}
