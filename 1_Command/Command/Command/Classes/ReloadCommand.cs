using System;

public class ReloadCommand : ICommand
{
    public void Execute(Player p)
    {
        p.Reload();
    }
}
