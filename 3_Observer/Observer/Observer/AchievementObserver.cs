using System;

public class AchievementObserver
{
    // OBSERVER

    public void CheckForAchievements(Player player, EventType eventType)
    {
        switch (eventType)
        {
            case EventType.ShotAChicken:
                if (player.ChickensHit == 5)
                    Console.WriteLine("\nACHIEVEMENT UNLOCKED!!!! *Shot 5 chickens!*");
                break;
            case EventType.Jumped:
                break;
            case EventType.ReloadingGun:
                Random r = new Random();
                if (r.Next(5) > 2)
                    Console.WriteLine("\nACHIEVEMENT UNLOCKED!!!! *Ultra reload!*");
                break;
            case EventType.Died:
                Console.WriteLine("\nACHIEVEMENT UNLOCKED!!!! *Player has died*\nGame will now end. Bye.");
                Program.GameShouldRun = false;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(eventType), eventType, null);
        }
    }
}
