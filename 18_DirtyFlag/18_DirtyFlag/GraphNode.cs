using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_DirtyFlag
{
    class GraphNode
    {
        public Transform Local { get; private set; }
        private Mesh _mesh;

        // optimized:
        public bool Dirty { get; private set; }
        private Transform _world; // cached version of the object's transform in world space

        private static int MAX_CHILDREN = 10;
        private GraphNode[] _children = new GraphNode[MAX_CHILDREN];
        private int _numChildren;

        public GraphNode(Mesh mesh, string name)
        {
            _mesh = mesh; // ... do some null check for the mesh for non-visual nodes
            Local = new Transform(name);
            Dirty = true; // always starts out "dirty", since the data is out of date (i.e., local and world coordinates are out of sync)
        }

        public void AddChildNode(GraphNode child)
        {
            if (_numChildren + 1 > MAX_CHILDREN)
                return;

            _children[_numChildren] = child;
            _numChildren++;
        }

        public void SetTransform(Transform local)
        {
            this.Local = local;
            this.Dirty = true;

            Console.WriteLine("[{0} has been updated]", this.Local.Name);
            // every time the Transform is changed locally, its world coordinate is invalidated
            // same thing happens for all children nodes; however, these are set in DirtyFlagRender() instead!
        }


        // Non-optimized traversal of nodes
        public void SimpleRender(Transform parentWorld)
        {
            Transform world = Local.Combine_ExpensiveCalucations(parentWorld); // this object in world space
            // it's not optimized, since this Combine_ExpensiveCalucations() is called on every node in the graph for every frame!

            if (_mesh != null)
                Renderer.RenderMesh(_mesh, world);

            for (int i = 0; i < _numChildren; i++)
            {
                _children[i].SimpleRender(world);
            }
        }

        // Optimized using dirty flag
        public void DirtyFlagRender(Transform parentWorld, bool dirty)
        {
            dirty |= Dirty; // if any of the two are TRUE, use that

            // we only do the calculations if this node is dirty (out of sync)
            if (dirty)
            {
                _world = Local.Combine_ExpensiveCalucations(parentWorld); // this object in world space (cache)
                Dirty = false;

                // we change our local _dirty, but we keep the parameter dirty unchanged and pass it to the children nodes
            }


            if (_mesh != null)
                Renderer.RenderMesh(_mesh, _world);

            for (int i = 0; i < _numChildren; i++)
            {
                // The children nodes are automatically assigned the dirty state from the parent node
                _children[i].DirtyFlagRender(_world, dirty);
            }
        }
    }
}
