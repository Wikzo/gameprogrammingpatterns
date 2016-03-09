using System.Collections.Generic;

namespace Component
{
    public class GameObject
    {
        public int PosX, PosY;
        public int Velocity;

        private readonly IInput _input;
        private readonly IGraphics _graphics;
        private readonly IPhysics _physics;

        private static List<Component> _components; 

        public GameObject(IInput input, IPhysics physics, IGraphics graphics)
        {
            _components = new List<Component>();

            _input = input;
            _physics = physics;
            _graphics = graphics;

            _components.Add(_input as Component);
            _components.Add(_physics as Component);
            _components.Add(_graphics as Component);
        }

        public static GameObject CreateDefaultObject()
        {
            return new GameObject(new InputComponent(), new PhysicsComponent(), new GraphicsComponent());
        }

        public void Update()
        {
            _input.Update(this);
            _physics.Update(this);
            _graphics.Update(this);
        }

        public void SendMessage(Message messageToSend)
        {
            foreach (Component c in _components)
            {
                c.Receive(messageToSend);
            }
        }
    }
}