using System;

namespace Component
{
    internal class PhysicsComponent : Component, IPhysics
    {
        public void Update(GameObject gameObject)
        {
            Console.WriteLine("Updating PhysicsComponent");
        }

        public override void Receive(Message message)
        {
            if (message.MessageType == MessageType.Physics)
                Console.WriteLine("{0} received message: {1}", this, message.MessageString);
        }
    }
}