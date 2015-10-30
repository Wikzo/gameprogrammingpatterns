using System;

public static class InputHandler
{
    public static ICommand HandleInput()
    {
        Console.WriteLine("\n---Possible input: 'shoot', 'jump', 'reload', 'die'---");

        Console.Write(">");


        string command = Console.ReadLine();

        Console.WriteLine("");


        if (command.ToLower() == "shoot") return new ShootCommand();
        if (command.ToLower() == "jump") return new JumpCommand();
        if (command.ToLower() == "reload") return new ReloadCommand();
        if (command.ToLower() == "die") return new DieCommand();

        Console.WriteLine("Invalid input! Try again...\n");

        return null;
    }
}