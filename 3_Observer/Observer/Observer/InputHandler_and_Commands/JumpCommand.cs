class JumpCommand : ICommand
{
    public void Execute(Player player)
    {
        player.Jump();
    }
}
