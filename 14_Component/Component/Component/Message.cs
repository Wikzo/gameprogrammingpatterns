namespace Component
{
    public enum MessageType
    {
        Input,
        Physics,
        Graphics,
        All
    }

    public class Message
    {
        public MessageType MessageType;
        public string MessageString;

        public Message(MessageType messageType, string messageString)
        {
            this.MessageType = messageType;
            this.MessageString = messageString;
        }
    }
}