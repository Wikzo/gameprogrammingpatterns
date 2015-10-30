class DieCommand : ICommand
{
    public void Execute(Player player)
    {
        player.Die();
    }
}
