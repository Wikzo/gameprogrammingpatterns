using System;

// "Invoker"

public static class InputHandler
{
    public static ICommand HandleInput()
    {
        Console.WriteLine("Possible input: A, B, X, Y\n>");

        ConsoleKeyInfo c = Console.ReadKey();

        Console.WriteLine("\n");

        if (c.KeyChar.ToString().ToLower() == "a") return new JumpCommand();
        if (c.KeyChar.ToString().ToLower() == "b") return new ShootCommand();
        if (c.KeyChar.ToString().ToLower() == "x") return new CrouchCommand();
        if (c.KeyChar.ToString().ToLower() == "y") return new ReloadCommand();

        Console.WriteLine("Invalid input! Try again...\n");

        return null;
    }
}
