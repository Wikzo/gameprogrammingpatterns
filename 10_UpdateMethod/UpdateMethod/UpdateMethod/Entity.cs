using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateMethod
{
    class Entity : IUpdatable
    {
        protected int _x, _y;
        protected string _name;
        protected UpdateSystem _system;
        public Entity(string name, UpdateSystem system)
        {
            _name = name;
            _system = system;

            Enable();

        }

        public void Enable()
        {
            _system.OnUpdateCollection += OnEnable;
        }

        public void Disable()
        {
            _system.OnUpdateCollection += OnDisable;
        }

        private void OnEnable()
        {
            Console.WriteLine(_name + " enabled");

            _system.AddEntity(this);
            _system.OnUpdateCollection -= OnEnable;
        }

        private void OnDisable()
        {
            Console.WriteLine(_name + " disabled");

            _system.RemoveEntity(this);
            _system.OnUpdateCollection -= OnDisable;
        }

        public void Update(double delta)
        {
            _x++;
            _y++;

            Console.WriteLine("Updating " + _name);
        }
    }
}
