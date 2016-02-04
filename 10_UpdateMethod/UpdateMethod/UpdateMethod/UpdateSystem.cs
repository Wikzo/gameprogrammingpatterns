using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateMethod
{
    class UpdateSystem
    {
        private List<Entity> _entities = new List<Entity>();

        public delegate void UpdateCollection();
        public event UpdateCollection OnUpdateCollection;

        public void Update(float delta)
        {
            int count = _entities.Count;

            // looping backwards prevents the iterated entities to be shifted in the collection
            for (int i = count - 1; i >= 0; i--)
                _entities[i].Update(delta);

            // entities are added/removed after one full update loop
            // this is to prevent any of the entities being skipped
            if (OnUpdateCollection != null) OnUpdateCollection();
        }

        public UpdateSystem AddEntity(Entity e)
        {
            _entities.Add(e);

            return this;
        }

        public void RemoveEntity(Entity e)
        {
            if (_entities.Contains(e))
                _entities.Remove(e);
            else
                throw new ArgumentException("Entity " + e + " not found!");
        }
    }
}
