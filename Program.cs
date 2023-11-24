using System;

// Абстрактный класс "Автомобиль"
abstract class Car
{
    public string Name { get; }
    public int Speed { get; set; }
    public int Distance { get; set; }

    public event EventHandler<string> FinishEvent;

    public Car(string name, int speed)
    {
        Name = name;
        Speed = speed;
        Distance = 0;
    }

    public abstract void Move();

    protected virtual void OnFinish()
    {
        FinishEvent?.Invoke(this, $"{Name} финишировал!");
    }
}

// Класс "Спортивный автомобиль"
class SportsCar : Car
{
    public SportsCar(string name, int speed) : base(name, speed) { }

    public override void Move()
    {
        Distance += Speed;
        if (Distance >= 100)
            OnFinish();
    }
}

// Класс "Легковой автомобиль"
class Sedan : Car
{
    public Sedan(string name, int speed) : base(name, speed) { }

    public override void Move()
    {
        Distance += Speed;
        if (Distance >= 100)
            OnFinish();
    }
}

// Класс "Грузовик"
class Truck : Car
{
    public Truck(string name, int speed) : base(name, speed) { }

    public override void Move()
    {
        Distance += Speed;
        if (Distance >= 100)
            OnFinish();
    }
}

// Класс "Автобус"
class Bus : Car
{
    public Bus(string name, int speed) : base(name, speed) { }

    public override void Move()
    {
        Distance += Speed;
        if (Distance >= 100)
            OnFinish();
    }
}

// Класс "Игра гонок"
class RacingGame
{
    public delegate void StartRaceHandler();
    public event StartRaceHandler RaceStarted;

    public void StartRace()
    {
        RaceStarted?.Invoke();
    }

    public void RaceInfo(object sender, string message)
    {
        Console.WriteLine($"[Race Info] {message}");
    }

    public void WinnerInfo(object sender, string message)
    {
        Console.WriteLine($"[Winner Info] {message}");
    }
}

class Program
{
    static void Main()
    {
        RacingGame game = new RacingGame();

        SportsCar sportsCar = new SportsCar("Ferrari", 10);
        Sedan sedan = new Sedan("Toyota", 8);
        Truck truck = new Truck("Volvo", 5);
        Bus bus = new Bus("Mercedes", 7);

        game.RaceStarted += sportsCar.Move;
        game.RaceStarted += sedan.Move;
        game.RaceStarted += truck.Move;
        game.RaceStarted += bus.Move;

        sportsCar.FinishEvent += game.WinnerInfo;
        sedan.FinishEvent += game.WinnerInfo;
        truck.FinishEvent += game.WinnerInfo;
        bus.FinishEvent += game.WinnerInfo;

        

        game.StartRace();

        Console.ReadLine();
    }
}
