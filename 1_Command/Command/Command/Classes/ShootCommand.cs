using System;

public class ShootCommand : ICommand
{
    public void Execute(Player p)
    {
        p.Shoot();
    }
}
