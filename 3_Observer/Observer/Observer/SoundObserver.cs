using System;

public class SoundObserver
{
    public void CheckForJumpSound(Player player, EventType eventType)
    {
        if (eventType == EventType.Jumped)
            Console.WriteLine("[Jump sound played]");
    }
}
