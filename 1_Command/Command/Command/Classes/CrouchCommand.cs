using System;

public class CrouchCommand : ICommand
{
    public void Execute(Player p)
    {
        p.Crouch();
    }
}
