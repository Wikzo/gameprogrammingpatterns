    public class Subject
    {
        public delegate void Notify(Player e, EventType eventType);
        public event Notify OnNotify;

        public void NotifyMe(Player player, EventType eventType)
        {
            if (OnNotify != null)
                OnNotify(player, eventType);
        }

        public void RegisterObserver(Notify n)
        {
            OnNotify += n;
        }

        public void DeregisterObserver(Notify n)
        {
            OnNotify -= n;
        }
    }
