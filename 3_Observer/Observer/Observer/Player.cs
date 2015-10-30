using System;

public class Player
{
    private Subject _subject;
    private Random _random;
    private int _chickensHit;
    private bool _isAlive;

    public int ChickensHit { get { return _chickensHit; } }

    public Player(Subject s)
    {
        this._subject = s;
        _random = new Random();
    }

    public void ShootChickens()
    {
        Console.WriteLine("Shooting...");
        if (_random.Next(3) > 1)
        {
            Console.WriteLine("Hit a chicken!");
            _chickensHit++;

            // cannot invoke the delegate directly from this class?
            _subject.NotifyMe(this, EventType.ShotAChicken);

        }
        else
            Console.WriteLine("Missed!");

    }


    public void Die()
    {
        Console.WriteLine("Player has died...");
        _subject.NotifyMe(this, EventType.Died);
    }

    public void Reload()
    {
        Console.WriteLine("Reloading the gun...");
        _subject.NotifyMe(this, EventType.ReloadingGun);
    }

    public void Jump()
    {
        Console.WriteLine("JUMP!");
        _subject.NotifyMe(this, EventType.Jumped);
    }
}
