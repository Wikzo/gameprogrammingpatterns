using System;

public class JumpCommand : ICommand
{
    public void Execute(Player p)
    {
        p.Jump();
    }
}
