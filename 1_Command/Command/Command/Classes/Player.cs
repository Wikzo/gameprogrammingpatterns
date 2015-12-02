using System;


// "Receiver"

public class Player
{
    public Player(string name)
    {
        this.Name = name;
    }

    public string Name { get; }

    public void Jump()
    {
        Console.WriteLine(Name + " is jumping!");

    }

    public void Crouch()
    {
        Console.WriteLine(Name + " is crouching!");


    }

    public void Reload()
    {
        Console.WriteLine(Name + " is reloading!");


    }

    public void Shoot()
    {
        Console.WriteLine(Name + " is shooting!");


    }
}
