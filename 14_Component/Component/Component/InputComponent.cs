using System;

namespace Component
{
    internal class InputComponent : Component, IInput
    {
        public void Update(GameObject gameObject)
        {
            Console.WriteLine("Updating InputComponent");
        }

        public override void Receive(Message message)
        {
            if (message.MessageType == MessageType.Input)
                Console.WriteLine("{0} received message: {1}", this, message.MessageString);

        }
    }
}