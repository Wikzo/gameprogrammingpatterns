class ReloadCommand : ICommand
{
    public void Execute(Player player)
    {
        player.Reload();
    }
}
