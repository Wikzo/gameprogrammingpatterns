using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component
{
    class Program
    {
        static void Main(string[] args)
        {
            GameObject gameObject = GameObject.CreateDefaultObject();

            gameObject.Update();

            gameObject.SendMessage(new Message(MessageType.Input, "Testing input message"));

            Console.ReadLine();
        }
    }
}
