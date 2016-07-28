using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_DirtyFlag
{
    class GraphNode
    {
        private Transform _local; // describes where the object is relative to its parent
        private Mesh _mesh;

        private static int MAX_CHILDREN = 10;
        private GraphNode[] _children = new GraphNode[MAX_CHILDREN];
        private int _numChildren;

        public GraphNode(Mesh mesh)
        {
            _mesh = mesh;
            // ... do some null check for the mesh for non-visual nodes

            _local = Transform.Origin;
        }

        // Non-optimized traversal of nodes
        public void Render(Transform parentWorld)
        {
            Transform world = _local.Combine(parentWorld); // this object in world space
            // it's not optimized, since this Combine() is called on every node in the graph for every frame!

            if (_mesh != null)
                Renderer.RenderMesh(_mesh, world);

            for (int i = 0; i < _numChildren; i++)
            {
                _children[i].Render(world);
            }

        }
    }
}
