using System;

namespace Component
{
    internal class GraphicsComponent : Component, IGraphics
    {
        public void Update(GameObject gameObject)
        {
            Console.WriteLine("Updating GraphicsComponent");

        }

        public override void Receive(Message message)
        {
            if (message.MessageType == MessageType.Graphics)
                Console.WriteLine("{0} received message: {1}", this, message.MessageString);

        }
    }
}