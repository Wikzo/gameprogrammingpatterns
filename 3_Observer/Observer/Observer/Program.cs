using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{

    public static bool GameShouldRun = true;
    static void Main(string[] args)
    {
        // make observer
        AchievementObserver achievementObserver = new AchievementObserver();
        SoundObserver soundObserver = new SoundObserver();

        // make subject to observe
        Subject subject = new Subject();

        // make subject become observed
        subject.RegisterObserver(achievementObserver.CheckForAchievements);
        subject.RegisterObserver(soundObserver.CheckForJumpSound);

        // make player
        Player player = new Player(subject);

        ICommand command = null;

        while (GameShouldRun)
        {
            command = InputHandler.HandleInput();

            if (command != null)
                command.Execute(player);
        }

        subject.DeregisterObserver(achievementObserver.CheckForAchievements);
        subject.DeregisterObserver(soundObserver.CheckForJumpSound);
    }
}
